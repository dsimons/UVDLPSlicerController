#include "stdafx.h"
#include "ProjectImage.h"



// Input Channel mappings.
// hiermee maak je de kans op fouten kleiner omdat dit makkelijker leesbaar is. Je ziet sneller
// een fout als je IN_NEXT_IMAGE ziet als kanaal nummer dan als je 2 ziet als vaste waarde.
const unsigned _int8 IN_ENABLE_LAMP = 0;
const unsigned _int8 IN_RESET       = 1;
const unsigned _int8 IN_NEXT_IMAGE  = 2;

const unsigned _int8 NUM_INPUTS     = 3;

// Output Channel mappings
// Een naam voor elk kanaal nummer voor de leesbaarheid.
const unsigned _int8 OUT_LAMP_ACTIVE   = 0;
const unsigned _int8 OUT_IMG_AVAILABLE = 1;
// Max aantal plaatjes: 4095
const unsigned _int8 OUT_CUR_IMG_B0    = 2; // 1ste bit (1)
const unsigned _int8 OUT_CUR_IMG_B1    = 3; // 2de bit (2)
const unsigned _int8 OUT_CUR_IMG_B2    = 4; // 3de bit (4)
const unsigned _int8 OUT_CUR_IMG_B3    = 5; // 4de bit (8)
const unsigned _int8 OUT_CUR_IMG_B4    = 6; // 5de bit (16)
const unsigned _int8 OUT_CUR_IMG_B5    = 7; // 6de bit (32)
const unsigned _int8 OUT_CUR_IMG_B6    = 8; // 7de bit (64)
const unsigned _int8 OUT_CUR_IMG_B7    = 9; // 8ste bit (128)
const unsigned _int8 OUT_CUR_IMG_B8    = 10; // 9de bit (256)
const unsigned _int8 OUT_CUR_IMG_B9    = 11; // 10de bit (512)
const unsigned _int8 OUT_CUR_IMG_B10   = 12; // 11de bit (1024)
const unsigned _int8 OUT_CUR_IMG_B11   = 13; // 12de bit (2048)

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
		Name[3] = 0;
		break;
	}
}
BOOL start = false;
BOOL pause = false;
BOOL stop = true;
BOOL pconnect = false;
HANDLE pipe = INVALID_HANDLE_VALUE;
HANDLE pipeEvent = NULL;
const wchar_t *pipeName = L"\\\\.\\pipe\\3dPrinter";
const int unsigned BUF_SIZE = 128;
wchar_t pipeBuffer[BUF_SIZE];
BOOL pipeResult;


// http://msdn.microsoft.com/en-us/library/windows/desktop/aa365690(v=vs.85).aspx
LPCTSTR ErrorMessage(DWORD error) { 

    LPVOID lpMsgBuf;

    FormatMessage(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | 
        FORMAT_MESSAGE_FROM_SYSTEM |
        FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL,
        error,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPTSTR) &lpMsgBuf,
        0, NULL );

    return((LPCTSTR)lpMsgBuf);
}

void _stdcall LogError(wchar_t *message) {
	FILE *logFile;
	fopen_s(&logFile, "C:\\tmp\\ProjectImage.txt", "a+");
	fwprintf_s(logFile, L"ERROR: %s\n", message);
	fclose(logFile);
	MessageBoxW(NULL,message,TEXT("ProjectImage Error"), MB_OKCANCEL);
}

void _stdcall LogMessage(wchar_t *message) {
	FILE *logFile;
	fopen_s(&logFile, "C:\\tmp\\ProjectImage.txt", "a+");
	fwprintf_s(logFile, L"INFO: %s\n", message);
	fclose(logFile);
	MessageBoxW(NULL,message,TEXT("ProjectImage Message"), MB_OKCANCEL);
}

void _stdcall HandleMessage(wchar_t *message) {
	LogMessage(pipeBuffer);
}

// internal call to tear down named pipe client to disconnect from creation workshop
void _stdcall DisconnectPipe(double *PInput, double *POutput) {
	if (pipe != INVALID_HANDLE_VALUE) {
		CloseHandle(pipe);
	}
	if (pipeEvent != NULL) {
	    CloseHandle(pipeEvent);
	}
	pconnect = false;
	POutput[OUT_PCONNECT] = pconnect;
}

void _stdcall ReadPipe(double *PInput, double *POutput) {
    DWORD numBytesToRead    = (BUF_SIZE-1) * sizeof(wchar_t);
    DWORD numBytesRead      = 0;
    DWORD error             = 0;
    LPCTSTR errMsg          = NULL;
	OVERLAPPED overlapped   = {0};

	if (pipe == INVALID_HANDLE_VALUE) {
		return;
	}

	pipeResult = ReadFile(pipe, pipeBuffer, numBytesToRead, &numBytesRead, &overlapped);
	error = GetLastError();
	if (pipeResult) {
		// got a result
        pipeBuffer[numBytesRead / sizeof(wchar_t)] = L'\0'; // null terminate the string
		HandleMessage(pipeBuffer);
	} else {
		switch (error) {
			case ERROR_HANDLE_EOF:
				{
					printf("\nReadFile returned FALSE and an unexpected EOF.\n");
					DisconnectPipe(PInput, POutput);
					break;
				}
			case ERROR_IO_PENDING:
				{
					// nothing to do
					break;
				}
			default:
				{
					errMsg = ErrorMessage(error);
                    printf("ReadFile GLE unhandled (%d): %s\n", error, errMsg); 
					LogError((wchar_t *)errMsg);
					DisconnectPipe(PInput, POutput);
                    LocalFree((LPVOID)errMsg);
                    break;
				}
		}
	}
}

// internal call to set up named pipe client to connect to creation workshop
void _stdcall ConnectPipe(double *PInput, double *POutput) {
	pconnect = false;
	POutput[OUT_PCONNECT] = pconnect;

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
        DWORD dwError = GetLastError();
        LPCTSTR errMsg = ErrorMessage(dwError);
        printf("Could not open pipe (%d): %s\n", dwError, errMsg);
		LocalFree((LPVOID)errMsg);
		LogError(TEXT("Cannot connect to Creation Workshop"));
	} else {
		pipeEvent = CreateEvent(NULL, TRUE, FALSE, NULL);
		if (pipeEvent == NULL) { 
			DWORD dwError = GetLastError();
			LPCTSTR errMsg = ErrorMessage(dwError);
			printf("Could not CreateEvent: %d %s\n", dwError, errMsg); 
			LocalFree((LPVOID)errMsg);
		} else {
			pconnect = true;
			ReadPipe(PInput, POutput);
		}
	}

	POutput[OUT_PCONNECT] = pconnect;
}

// Wordt door profilab aangeroepen als de simulatie gestart wordt, initializatie code
PROJECTIMAGE_API void _stdcall CSimStart(double *PInput, double *POutput, double *PUser) {
	ConnectPipe(PInput, POutput);
}

// Dit is de functie die het werkelijke rekenwerk van de DLL doet. Wordt door PROFILAB aangeroepen.
PROJECTIMAGE_API void _stdcall CCalculate(double *PInput, double *POutput, double *PUser) {
	// De PInput bevat een array met NUM_INPUTS double waardes voor elke input (double is double precision floating point)
	// de betekenis kan je halen uit de definities helemaal bovenaan.

	// Voorbeeld, normaal moet je eerst wat doen, zoals een zwart plaatje plaatsen op het projectie scherm
	// Als de lamp enable input laag is (kleiner dan < 2.5)
	if (PInput[IN_ENABLE_LAMP] < SWITCH_LEVEL) {
		POutput[OUT_LAMP_ACTIVE] = LOW;
	} else {
		POutput[OUT_LAMP_ACTIVE] = HIGH;
	}

	ReadPipe(PInput, POutput);
	POutput[OUT_START] = start ? HIGH : LOW;
	POutput[OUT_PAUSE] = pause ? HIGH : LOW;
	POutput[OUT_STOP] = stop ? HIGH : LOW;
	POutput[OUT_PCONNECT] = pconnect ? HIGH : LOW;

	// De POutput bevat een array met NUM_OUTPUTS double waardes voor elke output.

	// De PUser is een user area met geheugen om in te werken. Hier is ruimte voor maximaal 100 doubles en deze
	// dll is er zelf verantwoordelijk voor om dit geheugen te managen.
}

// Dit is de functie die aangeroepen wordt door PROFILAB als de simulatie stopt, voor het opruimen van gebruikte resources
PROJECTIMAGE_API void _stdcall CSimStop(double *PInput, double *POutput, double *PUser)
{
	DisconnectPipe(PInput, POutput);
}

// Dit is voor het configuratiemenu binnen PROFILAB, hier kan een scherm gemaakt worden om configuratie instellingen te doen.
PROJECTIMAGE_API void _stdcall CConfigure(double *PUser)
{
	MessageBoxW(NULL,TEXT("There are no settings"),TEXT("Project Image DLL Config"), MB_OKCANCEL);
}
