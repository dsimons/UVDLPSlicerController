#ifdef EXPORTS
#define NAMED_PIPE_TO_PROFILAB_API extern "C" __declspec(dllexport)
// Internal DLL use only
void WriteToPipe(wchar_t *message);
#else
#define NAMED_PIPE_TO_PROFILAB_API extern "C" __declspec(dllimport)
#endif

NAMED_PIPE_TO_PROFILAB_API unsigned char _stdcall NumInputs();
NAMED_PIPE_TO_PROFILAB_API unsigned char _stdcall NumOutputs();
NAMED_PIPE_TO_PROFILAB_API void _stdcall GetInputName(unsigned _int8 Channel, unsigned char *Name);
NAMED_PIPE_TO_PROFILAB_API void _stdcall GetOutputName(unsigned _int8 Channel, unsigned char *Name);
NAMED_PIPE_TO_PROFILAB_API void _stdcall CSimStart(double *PInput, double *POutput, double *PUser);
NAMED_PIPE_TO_PROFILAB_API void _stdcall CCalculate(double *PInput, double *POutput, double *PUser);
NAMED_PIPE_TO_PROFILAB_API void _stdcall CSimStop(double *PInput, double *POutput, double *PUser);
NAMED_PIPE_TO_PROFILAB_API void _stdcall CConfigure(double *PUser);

// Output Channel mappings
// ui commands from creation workshop
const unsigned _int8 OUT_START = 0;
const unsigned _int8 OUT_PAUSE = 1;
const unsigned _int8 OUT_STOP  = 2;
const unsigned _int8 OUT_SIG_PRINT = 3;
const unsigned _int8 OUT_PCONNECT = 4;
const unsigned _int8 NUM_OUTPUTS  = 5;

// Output binary waarde, je kan elk output kanaal instellen met 0 of 5 en 5 is high.
const double LOW = 0;
const double HIGH = 5;
const double SWITCH_LEVEL = 2.5; // Laag is < 2.5 hoog is > 2.5 volgens specificatie PROFILAB

const unsigned _int8 NUM_INPUTS = 1;
const unsigned _int8 IN_RDY = 0;