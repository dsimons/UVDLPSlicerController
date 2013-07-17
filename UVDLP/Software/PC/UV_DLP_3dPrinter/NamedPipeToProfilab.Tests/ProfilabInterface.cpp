#include "stdafx.h"
#include "CppUnitTest.h"
#include <NamedPipeToProfilab.h>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace NamedPipeToProfilabTests
{		
	TEST_CLASS(TestProfilabInterface)
	{
	public:
		
		TEST_METHOD(TestNumInputsAndOutputs)
		{
			Assert::AreEqual((unsigned char)0, ::NumInputs());
			Assert::AreEqual((unsigned char)5, ::NumOutputs());
		}


		TEST_METHOD(TestSequenceOfEvents)
		{
			double* in = (double*)malloc(200 * sizeof(double));
			double* out = (double*)malloc(200 * sizeof(double));
			double* user = (double*)malloc(200 * sizeof(double));
			
			HANDLE pipe = OpenPipe();

			::CSimStart(in, out, user);

			ConnectNamedPipe(pipe, NULL); // Block until DLL connected

			::CCalculate(in, out, user);

			Assert::AreEqual(HIGH, out[OUT_PCONNECT]);

			Assert::AreEqual(LOW, out[OUT_START]);

			WriteToPipe(pipe, L"START");

			::CCalculate(in, out, user);

			Assert::AreEqual(HIGH, out[OUT_START]);

			Assert::AreEqual(LOW, out[OUT_SIG_PRINT]);

			WriteToPipe(pipe, L"LAYER_COMPLETED");

			::CCalculate(in, out, user);

			Assert::AreEqual(HIGH, out[OUT_SIG_PRINT]);

			::CCalculate(in, out, user);

			Assert::AreEqual(LOW, out[OUT_SIG_PRINT]);


			::CSimStop(in, out, user);
			
			CloseHandle(pipe);
			
			free(in);
			free(out);
			free(user);

		}

		HANDLE OpenPipe()
		{
			return CreateNamedPipe(
				L"\\\\.\\pipe\\3dPrinter", // name of the pipe
				PIPE_ACCESS_DUPLEX,
				PIPE_TYPE_BYTE, // send data as a byte stream
				1, // only allow 1 instance of this pipe
				128 * sizeof(wchar_t),
				128 * sizeof(wchar_t),
				0, // use default wait time
				NULL // use default security attributes
			);
		}

		void WriteToPipe(HANDLE pipe, wchar_t *message) {
			DWORD numBytesWritten = 0;
			WriteFile(
				pipe, // handle to our outbound pipe
				message, // data to send
				wcslen(message) * sizeof(wchar_t), // length of data to send (bytes)
				&numBytesWritten, // will store actual amount of data sent
				NULL // not using overlapped IO
			);
		}

	};
}