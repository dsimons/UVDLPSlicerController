#include "stdafx.h"
#include "ProjectImage.h"

// Input Channel mappings.
// hiermee maak je de kans op fouten kleiner omdat dit makkelijker leesbaar is. Je ziet sneller
// een fout als je IN_NEXT_IMAGE ziet als kanaal nummer dan als je 2 ziet als vaste waarde.
const unsigned _int8 IN_ENABLE_LAMP = 0; // unused
const unsigned _int8 IN_RESET       = 1; // unused
const unsigned _int8 IN_NEXT_IMAGE  = 2; // unused

const unsigned _int8 NUM_INPUTS     = 3;

// Output Channel mappings
// Een naam voor elk kanaal nummer voor de leesbaarheid.
const unsigned _int8 OUT_LAMP_ACTIVE   = 0; // unused
const unsigned _int8 OUT_IMG_AVAILABLE = 1; // unused
// Max aantal plaatjes: 4095
const unsigned _int8 OUT_CUR_IMG_B0    = 2; // 1ste bit (1), unused
const unsigned _int8 OUT_CUR_IMG_B1    = 3; // 2de bit (2), unused
const unsigned _int8 OUT_CUR_IMG_B2    = 4; // 3de bit (4), unused
const unsigned _int8 OUT_CUR_IMG_B3    = 5; // 4de bit (8), unused
const unsigned _int8 OUT_CUR_IMG_B4    = 6; // 5de bit (16), unused
const unsigned _int8 OUT_CUR_IMG_B5    = 7; // 6de bit (32), unused
const unsigned _int8 OUT_CUR_IMG_B6    = 8; // 7de bit (64), unused
const unsigned _int8 OUT_CUR_IMG_B7    = 9; // 8ste bit (128), unused
const unsigned _int8 OUT_CUR_IMG_B8    = 10; // 9de bit (256), unused
const unsigned _int8 OUT_CUR_IMG_B9    = 11; // 10de bit (512), unused
const unsigned _int8 OUT_CUR_IMG_B10   = 12; // 11de bit (1024), unused
const unsigned _int8 OUT_CUR_IMG_B11   = 13; // 12de bit (2048), unused

// ui commands from creation workshop
const unsigned _int8 OUT_START         = 14;
const unsigned _int8 OUT_PAUSE         = 15;
const unsigned _int8 OUT_STOP          = 16;

// whether we have an active named pipe connection
const unsigned _int8 OUT_PCONNECT      = 17;

const unsigned _int8 NUM_OUTPUTS       = 18;

// Output binary waarde, je kan elk output kanaal instellen met 0 of 5 en 5 is high.
const double LOW = 0;
const double HIGH = 5;
const double SWITCH_LEVEL = 2.5; // Laag is < 2.5 hoog is > 2.5 volgens specificatie PROFILAB


// Aanroep PROFILAB, hiermee bepaalt PROFILAB hoeveel inputs er zijn
PROJECTIMAGE_API unsigned char _stdcall NumInputs()
{
	return NUM_INPUTS;
}

// Aanroep van PROFILAB om het aantal uitgangen te tellen
PROJECTIMAGE_API unsigned char _stdcall NumOutputs()
{
	return NUM_OUTPUTS;
}

// Hier wordt door PROFILAB voor elke ingang de naam opgehaald
PROJECTIMAGE_API void _stdcall GetInputName(unsigned _int8 Channel, unsigned char *Name) {
	// Met switch wordt de meegegeven waarde gecontroleerd en gematched met een waarde die bij de case staat.
	// Aan het einde van elke case staat break; om ervoor te zorgen dat hij niet verder gaat naar de volgende.
	switch (Channel) {
	case IN_ENABLE_LAMP:
		Name[0] = 'L';
		Name[1] = 'A';
		Name[2] = 'M';
		Name[3] = 'P';
		Name[4] = '_';
		Name[5] = 'E';
		Name[6] = 'N';
		Name[7] = 0;
		break;
	case IN_RESET:
		Name[0] = 'R';
		Name[1] = 'S';
		Name[2] = 'T';
		Name[3] = 0;
		Name[4] = 0;
		Name[5] = 0;
		Name[6] = 0;
		Name[7] = 0;
		break;
	case IN_NEXT_IMAGE:
		Name[0] = 'N';
		Name[1] = 'E';
		Name[2] = 'X';
		Name[3] = 'T';
		Name[4] = '_';
		Name[5] = 'I';
		Name[6] = 'M';
		Name[7] = 'G';
		Name[8] = 0;
		break;
	}
}

// Hiermee bepaalt PROFILAB de Namen van de uitgangen
PROJECTIMAGE_API void _stdcall GetOutputName(unsigned _int8 Channel, unsigned char *Name) {
	switch (Channel) {
	case OUT_IMG_AVAILABLE:
		Name[0] = 'I';
		Name[1] = 'M';
		Name[2] = 'G';
		Name[3] = '_';
		Name[4] = 'A';
		Name[5] = 'V';
		Name[6] = 'L';
		Name[7] = 0;
		break;
	case OUT_LAMP_ACTIVE:
		Name[0] = 'L';
		Name[1] = 'A';
		Name[2] = 'M';
		Name[3] = 'P';
		Name[4] = '_';
		Name[5] = 'O';
		Name[6] = 'N';
		Name[7] = 0;
		break;
	case OUT_CUR_IMG_B0:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '0';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B1:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '1';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B2:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '2';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B3:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '3';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B4:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '4';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B5:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '5';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B6:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '6';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B7:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '7';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B8:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '8';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B9:
		Name[0] = 'B';
		Name[1] = '0';
		Name[2] = '9';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B10:
		Name[0] = 'B';
		Name[1] = '1';
		Name[2] = '0';
		Name[3] = 0;
		break;
	case OUT_CUR_IMG_B11:
		Name[0] = 'B';
		Name[1] = '1';
		Name[2] = '1';
		Name[3] = 0;
		break;
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
		Name[3] = 0;
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
// memorz block

BOOL start    = false;
BOOL pause    = false;
BOOL stop     = true;
BOOL pconnect = false;

HANDLE pipe                   = INVALID_HANDLE_VALUE;
const wchar_t *pipeName       = L"\\\\.\\pipe\\3dPrinter";
const int unsigned BUF_SIZE   = 128;
wchar_t pipeBuffer[BUF_SIZE];
BOOL pipeResult;
OVERLAPPED pipeOverlapped     = {0};
BOOL pipeIOWait               = false;



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
	fopen_s(&logFile, "C:\\tmp\\ProjectImage.txt", "a+");
	fwprintf_s(logFile, L"ERROR: %s\n", message);
	fclose(logFile);
	MessageBoxW(NULL,message,L"ProjectImage Error", MB_OK);
}

// helper function to log informational status to a file
void _stdcall LogMessage(wchar_t *message) {
	FILE *logFile;
	fopen_s(&logFile, "C:\\tmp\\ProjectImage.txt", "a+");
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
	pause = true;
}

// called whenever we get a CANCEL message
void _stdcall HandleCancel() {
	start = false;
	pause = false;
	stop = true;
}

// called whenever we get a message.
// Decides what to do with the message received by sending it to HandleXXX().
void _stdcall HandleMessage(wchar_t *message) {
	LogMessage(pipeBuffer);
	if (wcsncmp(message, L"START", 5) == 0) {
		HandleStart();
	} else if (wcsncmp(message, L"PAUSE", 5) == 0) {
		HandlePause();
	} else if (wcsncmp(message, L"CANCEL", 5) == 0) {
		HandleCancel();
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
	LogError(errMsg);
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
		LogError(L"Cannot connect to Creation Workshop");
	} else {
		// we managed to connect to creation workshop
		pconnect = true;
		POutput[OUT_PCONNECT] = HIGH;
		ReadPipe(PInput, POutput);
	}
}

// Wordt door profilab aangeroepen als de simulatie gestart wordt, initializatie code
PROJECTIMAGE_API void _stdcall CSimStart(double *PInput, double *POutput, double *PUser) {
	ConnectPipe(PInput, POutput);
}

// Dit is de functie die het werkelijke rekenwerk van de DLL doet. Wordt door PROFILAB aangeroepen.
PROJECTIMAGE_API void _stdcall CCalculate(double *PInput, double *POutput, double *PUser) {
	// De PInput bevat een array met NUM_INPUTS double waardes voor elke input (double is double precision floating point)
	// de betekenis kan je halen uit de definities helemaal bovenaan.

	// De POutput bevat een array met NUM_OUTPUTS double waardes voor elke output.

	// De PUser is een user area met geheugen om in te werken. Hier is ruimte voor maximaal 100 doubles en deze
	// dll is er zelf verantwoordelijk voor om dit geheugen te managen.

	// read messages from the pipe to creation workshop. This reads 0 or
	// 1 message, so it has to be called multiple times. We don't arrange
	// for that ourselves, since ProfiLab knows to invoke CCalculate()
	// frequently
	ReadPipe(PInput, POutput);

	// set the latest state as we understand it from creation workshop.
	// Because of the async reading of messages, this state is up to 2
	// invocations of CCalculate() behind of reality. That's ok because
	// CCalculate() is called pretty frequently :)
	POutput[OUT_START] = start ? HIGH : LOW;
	POutput[OUT_PAUSE] = pause ? HIGH : LOW;
	POutput[OUT_STOP] = stop ? HIGH : LOW;
	POutput[OUT_PCONNECT] = pconnect ? HIGH : LOW;
}

// Dit is de functie die aangeroepen wordt door PROFILAB als de simulatie stopt, voor het opruimen van gebruikte resources
PROJECTIMAGE_API void _stdcall CSimStop(double *PInput, double *POutput, double *PUser)
{
	DisconnectPipe(PInput, POutput);
}

// Dit is voor het configuratiemenu binnen PROFILAB, hier kan een scherm gemaakt worden om configuratie instellingen te doen.
PROJECTIMAGE_API void _stdcall CConfigure(double *PUser)
{
	MessageBoxW(NULL,L"There are no settings",L"Project Image DLL Config", MB_OK);
}
