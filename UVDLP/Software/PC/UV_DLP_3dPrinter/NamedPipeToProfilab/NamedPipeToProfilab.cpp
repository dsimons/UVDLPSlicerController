#include "stdafx.h"
#include "NamedPipeToProfilab.h"



// Aanroep PROFILAB, hiermee bepaalt PROFILAB hoeveel inputs er zijn
NAMED_PIPE_TO_PROFILAB_API unsigned char _stdcall NumInputs()
{
	return NUM_INPUTS;
}

// Aanroep van PROFILAB om het aantal uitgangen te tellen
NAMED_PIPE_TO_PROFILAB_API unsigned char _stdcall NumOutputs()
{
	return NUM_OUTPUTS;
}

// Hier wordt door PROFILAB voor elke ingang de naam opgehaald
NAMED_PIPE_TO_PROFILAB_API void _stdcall GetInputName(unsigned _int8 Channel, unsigned char *Name)
{
	switch(Channel) {
	case IN_RDY:
		Name[0] = 'R';
		Name[1] = 'D';
		Name[2] = 'Y';
		Name[3] = 0;
		break;
	}
}

// Hiermee bepaalt PROFILAB de Namen van de uitgangen
NAMED_PIPE_TO_PROFILAB_API void _stdcall GetOutputName(unsigned _int8 Channel, unsigned char *Name)
{
	switch (Channel) {
	case OUT_START:
		Name[0] = 'S';
		Name[1] = 'T';
		Name[2] = 'A';
		Name[3] = 'R';
		Name[4] = 'T';
		Name[5] = 0;
		break;
	case OUT_PAUSE:
		Name[0] = 'P';
		Name[1] = 'A';
		Name[2] = 'U';
		Name[3] = 'S';
		Name[4] = 'E';
		Name[5] = 0;
		break;
	case OUT_STOP:
		Name[0] = 'S';
		Name[1] = 'T';
		Name[2] = 'O';
		Name[3] = 'P';
		Name[4] = 0;
		break;
	case OUT_SIG_PRINT:
		Name[0] = 'S';
		Name[1] = 'I';
		Name[2] = 'G';
		Name[3] = '_';
		Name[4] = 'P';
		Name[5] = 'R';
		Name[6] = 'I';
		Name[7] = 0;
		break;
	case OUT_PCONNECT:
		Name[0] = 'P';
		Name[1] = 'C';
		Name[2] = 'O';
		Name[3] = 'N';
		Name[4] = 0;
		break;
	}
}

// Local state variables for the connection to creation workshop.
// Because these variables are declared globally in the DLL, we
// can only use this DLL _once_. If that ever needs changing, we
// would need to move this state information into the PUser
// memory block

BOOL start    = false;
BOOL pause    = false;
BOOL stop     = true;
BOOL pconnect = false;
BOOL print_signal = false;

HANDLE pipe                   = INVALID_HANDLE_VALUE;
const wchar_t *pipeName       = L"\\\\.\\pipe\\3dPrinter";
const int unsigned BUF_SIZE   = 128;
wchar_t pipeBuffer[BUF_SIZE];
BOOL pipeResult;
OVERLAPPED pipeOverlapped     = {0};
BOOL pipeIOWait               = false;
BOOL ready = true;



// helper function to convert error codes to error messages
// http://msdn.microsoft.com/en-us/library/windows/desktop/aa365690(v=vs.85).aspx
LPWSTR ErrorMessage(DWORD error) { 

	LPWSTR lpMsgBuf = NULL;

	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER | 
		FORMAT_MESSAGE_FROM_SYSTEM |
		FORMAT_MESSAGE_IGNORE_INSERTS,
		NULL,
		error,
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		(LPWSTR) &lpMsgBuf,
		0, NULL );

	return((LPWSTR)lpMsgBuf);
}

// helper function to log errors to a file as well as show an alert window
void _stdcall LogError(wchar_t *message) {
	FILE *logFile;
	fopen_s(&logFile, "NamedPipe.txt", "a+");
	fwprintf_s(logFile, L"ERROR: %s\n", message);
	fclose(logFile);
	MessageBoxW(NULL,message,L"ProjectImage Error", MB_OK);
}

// helper function to log informational status to a file
void _stdcall LogMessage(wchar_t *message) {
	FILE *logFile;
	fopen_s(&logFile, "NamedPipe.txt", "a+");
	fwprintf_s(logFile, L"INFO: %s\n", message);
	fclose(logFile);
	//MessageBoxW(NULL,message,L"ProjectImage Message", MB_OK);
}

// called whenever we get a START message
void _stdcall HandleStart() {
	start = true;
	pause = false;
	stop = false;
}

// called whenever we get a PAUSE message
void _stdcall HandlePause() {
	start = false;
	pause = true;
	stop = false;
}

// called whenever we get a CANCEL message
void _stdcall HandleCancel() {
	start = false;
	pause = false;
	stop = true;
}

void _stdcall PrintSignal() {
	if (print_signal) {
		MessageBoxW(NULL,L"Synchronisation error, print_signal received before previous was handled. Check delay between slice settings.",L"Named Pipe Error", MB_OK);
	}
	print_signal = true;
}

void _stdcall PostBackReadyStatus() {
	if (ready) {
		WriteToPipe(L"READY");
	} else {
		WriteToPipe(L"BUSY");
	}
}

// called whenever we get a message.
// Decides what to do with the message received by sending it to HandleXXX().
void _stdcall HandleMessage(wchar_t *message) {
	LogMessage(pipeBuffer);
	if (wcsncmp(message, L"START", 5) == 0) {
		HandleStart();
	} else if (wcsncmp(message, L"PAUSE", 5) == 0) {
		HandlePause();
	} else if (wcsncmp(message, L"CANCEL", 6) == 0) {
		HandleCancel();
	} else if (wcsncmp(message, L"LAYER_COMPLETED", 15) == 0) {
		PrintSignal();
	} else if (wcsncmp(message, L"GET_READY_STATUS", 16) == 0) {
		PostBackReadyStatus();
	}
}

// helper to tear down named pipe client to disconnect from creation workshop
void _stdcall DisconnectPipe(double *PInput, double *POutput) {
	if (pipe != INVALID_HANDLE_VALUE) {
		CloseHandle(pipe);
		pipe = INVALID_HANDLE_VALUE;
	}
	pconnect = false;
	POutput[OUT_PCONNECT] = LOW;
}

// helper to handle IO errors
// logs the error then disconnects the pipe
void _stdcall HandleIOError(double *PInput, double *POutput, DWORD error) {
	LPWSTR errMsg = ErrorMessage(error);
	// LogError(errMsg); Default behaviour omdat het gewoon de server is die uit gaat.
	DisconnectPipe(PInput, POutput);
	LocalFree(errMsg);
	memset(&pipeOverlapped,0,sizeof(pipeOverlapped)); // clear unused event handle
	pipeIOWait = false;
}

// helper to read one message from the pipe
// calls HandleMessage() if it reads a message.
// if there is no message it doesn't do much
void _stdcall ReadPipe(double *PInput, double *POutput) {
	DWORD numBytesToRead    = (BUF_SIZE-1) * sizeof(wchar_t);
	DWORD numBytesRead      = 0;
	DWORD error             = 0;
	LPWSTR errMsg           = NULL;

	if (pipe == INVALID_HANDLE_VALUE) {
		return;
	}

	if (pipeIOWait) {
		// we've previously called ReadFile() and we are now
		// asynchronously waiting to actually receive a message
		pipeResult = GetOverlappedResult(pipe, &pipeOverlapped, &numBytesRead, false);
		if (pipeResult) {
			pipeBuffer[numBytesRead / sizeof(wchar_t)] = L'\0'; // null terminate the string
			if (numBytesRead > 0) {
				//LogMessage(L"message after IO wait");
				HandleMessage(pipeBuffer);
			} else {
				//LogMessage(L"0 byte message after IO wait");
			}
			memset(&pipeOverlapped,0,sizeof(pipeOverlapped)); // clear unused event handle
			pipeIOWait = false;
		} else {
			error = GetLastError();
			switch (error) {
			case ERROR_IO_PENDING:
				{
					// this is not an "actual" error but it is how windows is telling us
					// "there is no message to be read"
					pipeIOWait = true;
					break;
				}
			case ERROR_IO_INCOMPLETE:
				{
					//LogError(L"TODO: calling GetOverlappedResult() when we are not in the right state");
					break;
				}
			default:
				{
					HandleIOError(PInput, POutput, error);
					break;
				}
			}
		}
	} else {
		// we aren't waiting for a message yet, so call ReadFile() to read the next message
		pipeResult = ReadFile(pipe, pipeBuffer, numBytesToRead, &numBytesRead, &pipeOverlapped);
		if (pipeResult) {
			// even though we are reading async, it is possible to get a message
			// here that was alreadz buffered and waiting to be handled
			pipeBuffer[numBytesRead / sizeof(wchar_t)] = L'\0'; // null terminate the string
			if (numBytesRead > 0) {
				//LogMessage(L"message without IO wait");
				HandleMessage(pipeBuffer);
			} else {
				//LogMessage(L"0 byte message without IO wait");
			}
			memset(&pipeOverlapped,0,sizeof(pipeOverlapped)); // clear unused event handle
			pipeIOWait = false;
		} else {
			error = GetLastError();
			switch (error) {
			case ERROR_IO_PENDING:
				{
					// this is normal. We've asked to read the next message
					// but it isn't here yet. We'll read it on a later invocation
					// of ReadPipe()
					pipeIOWait = true;
					break;
				}
			default:
				{
					HandleIOError(PInput, POutput, error);
					break;
				}
			}
		}
	}
}

void WriteToPipe(wchar_t *message) {
	if (pipe != INVALID_HANDLE_VALUE) {
		DWORD numBytesWritten = 0;
		WriteFile(
			pipe, // handle to our outbound pipe
			message, // data to send
			wcslen(message) * sizeof(wchar_t), // length of data to send (bytes)
			&numBytesWritten, // will store actual amount of data sent
			NULL // not using overlapped IO
		);
	}
}

// function to set up named pipe client to connect to creation workshop
void _stdcall ConnectPipe(double *PInput, double *POutput) {
	// set the pconnect output to 0 to indicate we aren't connected
	pconnect = false;
	POutput[OUT_PCONNECT] = LOW;

	// create the named pipe
	pipe = CreateFile(
		pipeName,
		GENERIC_READ | GENERIC_WRITE,
		FILE_SHARE_READ | FILE_SHARE_WRITE,
		NULL,
		OPEN_EXISTING,
		FILE_FLAG_OVERLAPPED, // async... FILE_ATTRIBUTE_NORMAL,
		NULL
		);

	if (pipe == INVALID_HANDLE_VALUE) {
		// this means we can't become a client to the named pipe
		// usually this happens because creation workshop is not running
		// it can also happen if we are running multiple instances of
		// this DLL (either using it multiple times in one profilab
		// project, or running profilab multiple times)
		DWORD error = GetLastError();
		LPWSTR errMsg = ErrorMessage(error);
		LocalFree(errMsg);
		LogMessage(lstrcat(L"Cannot connect to Creation Workshop: ", errMsg));
	} else {
		// we managed to connect to creation workshop
		pconnect = true;
		POutput[OUT_PCONNECT] = HIGH;
	}
}

// Wordt door profilab aangeroepen als de simulatie gestart wordt, initializatie code
NAMED_PIPE_TO_PROFILAB_API void _stdcall CSimStart(double *PInput, double *POutput, double *PUser)
{
	try {
		ConnectPipe(PInput, POutput);
	} catch (...) {
		// Will keep trying to get connected
	}
}

// Dit is de functie die het werkelijke rekenwerk van de DLL doet. Wordt door PROFILAB aangeroepen.
NAMED_PIPE_TO_PROFILAB_API void _stdcall CCalculate(double *PInput, double *POutput, double *PUser)
{
	// De PInput bevat een array met NUM_INPUTS double waardes voor elke input (double is double precision floating point)
	// de betekenis kan je halen uit de definities helemaal bovenaan.

	// De POutput bevat een array met NUM_OUTPUTS double waardes voor elke output.

	// De PUser is een user area met geheugen om in te werken. Hier is ruimte voor maximaal 100 doubles en deze
	// dll is er zelf verantwoordelijk voor om dit geheugen te managen.

	
	// Check input ready status before handling pipe requests
	if (PInput[IN_RDY] < SWITCH_LEVEL) {
		ready = false;
	} else {
		ready = true;
	}

	// read messages from the pipe to creation workshop. This reads 0 or
	// 1 message, so it has to be called multiple times. We don't arrange
	// for that ourselves, since ProfiLab knows to invoke CCalculate()
	// frequently
	if (pconnect) {
		ReadPipe(PInput, POutput);
	} else {
		try {
			ConnectPipe(PInput, POutput);
		} catch (...) {
			// Keep trying
		}
	}

	// set the latest state as we understand it from creation workshop.
	// Because of the async reading of messages, this state is up to 2
	// invocations of CCalculate() behind of reality. That's ok because
	// CCalculate() is called pretty frequently :)
	POutput[OUT_START] = start ? HIGH : LOW;
	POutput[OUT_PAUSE] = pause ? HIGH : LOW;
	POutput[OUT_STOP] = stop ? HIGH : LOW;
	POutput[OUT_PCONNECT] = pconnect ? HIGH : LOW;

	// Sync signalling. After each layer a short signal is placed on the output.
	if (print_signal) {
		POutput[OUT_SIG_PRINT] = HIGH;
		print_signal = false; // Pulse, next pass this will go back to LOW
	} else {
		POutput[OUT_SIG_PRINT] = LOW;
	}
}

// Dit is de functie die aangeroepen wordt door PROFILAB als de simulatie stopt, voor het opruimen van gebruikte resources
NAMED_PIPE_TO_PROFILAB_API void _stdcall CSimStop(double *PInput, double *POutput, double *PUser)
{
	if (pconnect) {
		DisconnectPipe(PInput, POutput);
	}
}

// Dit is voor het configuratiemenu binnen PROFILAB, hier kan een scherm gemaakt worden om configuratie instellingen te doen.
NAMED_PIPE_TO_PROFILAB_API void _stdcall CConfigure(double *PUser)
{
	MessageBoxW(NULL,L"There are no settings",L"Named Pipe DLL Config", MB_OK);
}
