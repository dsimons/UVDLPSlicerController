#include "stdafx.h"
#include "ProjectImage.h"



// Input Channel mappings.
// hiermee maak je de kans op fouten kleiner omdat dit makkelijker leesbaar is. Je ziet sneller
// een fout als je IN_NEXT_IMAGE ziet als kanaal nummer dan als je 2 ziet als vaste waarde.
const unsigned _int8 IN_ENABLE_LAMP = 0;
const unsigned _int8 IN_RESET = 1;
const unsigned _int8 IN_NEXT_IMAGE = 2;

// Output Channel mappings
// Een naam voor elk kanaal nummer voor de leesbaarheid.
const unsigned _int8 OUT_LAMP_ACTIVE = 0;
const unsigned _int8 OUT_IMG_AVAILABLE = 1;
// Max aantal plaatjes: 4095
const unsigned _int8 OUT_CUR_IMG_B0 = 2; // 1ste bit (1)
const unsigned _int8 OUT_CUR_IMG_B1 = 3; // 2de bit (2)
const unsigned _int8 OUT_CUR_IMG_B2 = 4; // 3de bit (4)
const unsigned _int8 OUT_CUR_IMG_B3 = 5; // 4de bit (8)
const unsigned _int8 OUT_CUR_IMG_B4 = 6; // 5de bit (16)
const unsigned _int8 OUT_CUR_IMG_B5 = 7; // 6de bit (32)
const unsigned _int8 OUT_CUR_IMG_B6 = 8; // 7de bit (64)
const unsigned _int8 OUT_CUR_IMG_B7 = 9; // 8ste bit (128)
const unsigned _int8 OUT_CUR_IMG_B8 = 10; // 9de bit (256)
const unsigned _int8 OUT_CUR_IMG_B9 = 11; // 10de bit (512)
const unsigned _int8 OUT_CUR_IMG_B10 = 12; // 11de bit (1024)
const unsigned _int8 OUT_CUR_IMG_B11 = 13; // 12de bit (2048)

// Output binary waarde, je kan elk output kanaal instellen met 0 of 5 en 5 is high.
const double LOW = 0;
const double HIGH = 5;
const double SWITCH_LEVEL = 2.5; // Laag is < 2.5 hoog is > 2.5 volgens specificatie PROFILAB


// Aanroep PROFILAB, hiermee bepaalt PROFILAB hoeveel inputs er zijn
PROJECTIMAGE_API unsigned char _stdcall NumInputs()
{
	return 3;
}

// Aanroep van PROFILAB om het aantal uitgangen te tellen
PROJECTIMAGE_API unsigned char _stdcall NumOutputs()
{
	return 14;
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
	}
}

// Wordt door profilab aangeroepen als de simulatie gestart wordt, initializatie code
PROJECTIMAGE_API void _stdcall CSimStart(double *PInput, double *POutput, double *PUser) {

}

// Dit is de functie die het werkelijke rekenwerk van de DLL doet. Wordt door PROFILAB aangeroepen.
PROJECTIMAGE_API void _stdcall CCalculate(double *PInput, double *POutput, double *PUser) {
	// De PInput bevat een array met 3 double waardes voor elke input (double is double precision floating point)
	// de betekenis kan je halen uit de definities helemaal bovenaan.

	// Voorbeeld, normaal moet je eerst wat doen, zoals een zwart plaatje plaatsen op het projectie scherm
	// Als de lamp enable input laag is (kleiner dan < 2.5)
	if (PInput[IN_ENABLE_LAMP] < SWITCH_LEVEL) {
		POutput[OUT_LAMP_ACTIVE] = LOW;
	} else {
		POutput[OUT_LAMP_ACTIVE] = HIGH;
	}

	// De POutput bevat een array met 14 double waardes voor elke output.

	// De PUser is een user area met geheugen om in te werken. Hier is ruimte voor maximaal 100 doubles en deze
	// dll is er zelf verantwoordelijk voor om dit geheugen te managen.
}

// Dit is de functie die aangeroepen wordt door PROFILAB als de simulatie stopt, voor het opruimen van gebruikte resources
PROJECTIMAGE_API void _stdcall CSimStop(double *PInput, double *POutput, double *PUser)
{
	//nichts zu tun
}

// Dit is voor het configuratiemenu binnen PROFILAB, hier kan een scherm gemaakt worden om configuratie instellingen te doen.
PROJECTIMAGE_API void _stdcall CConfigure(double *PUser)
{
	MessageBoxW(NULL,TEXT("Er zijn geen instellingen"),TEXT("Project Image DLL Config"), MB_OKCANCEL);
}
