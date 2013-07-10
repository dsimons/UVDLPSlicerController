// http://www.avid-insight.co.uk/2012/03/introduction-to-win32-named-pipes-cpp/

#include "stdafx.h"
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	BOOL result;

    wcout << "Connecting to pipe..." << endl;
 
    // Open the named pipe
    // Most of these parameters aren't very relevant for pipes.
    HANDLE pipe = CreateFile(
        L"\\\\.\\pipe\\3dPrinter",
        GENERIC_READ | GENERIC_WRITE,
        FILE_SHARE_READ | FILE_SHARE_WRITE,
        NULL,
        OPEN_EXISTING,
        FILE_ATTRIBUTE_NORMAL,
        NULL
    );
 
    if (pipe == INVALID_HANDLE_VALUE) {
        wcout << "Failed to connect to pipe." << endl;
        // look up error code here using GetLastError()
        system("pause");
        return 1;
    }
 
	wcout << "Sending data to pipe..." << endl;
 
    // This call blocks until a client process reads all the data
    const wchar_t *data = L"*** Hello From C++ client ***\n";
    DWORD numBytesWritten = 0;
    result = WriteFile(
        pipe, // handle to our outbound pipe
        data, // data to send
        wcslen(data) * sizeof(wchar_t), // length of data to send (bytes)
        &numBytesWritten, // will store actual amount of data sent
        NULL // not using overlapped IO
    );
 
 
    if (result) {
        wcout << "Number of bytes sent: " << numBytesWritten << endl;
    } else {
        wcout << "Failed to send data." << endl;
        // look up error code here using GetLastError()
    }

	wcout << "Reading data from pipe..." << endl;
 
    // The read operation will block until there is data to read
    wchar_t buffer[128];
    DWORD numBytesRead = 0;
    result = ReadFile(
        pipe,
        buffer, // the data from the pipe will be put here
        127 * sizeof(wchar_t), // number of bytes allocated
        &numBytesRead, // this will store number of bytes actually read
        NULL // not using overlapped IO
    );
 
    if (result) {
        buffer[numBytesRead / sizeof(wchar_t)] = '?'; // null terminate the string
        wcout << "Number of bytes read: " << numBytesRead << endl;
        wcout << "Message: " << buffer << endl;
    } else {
        wcout << "Failed to read data from the pipe." << endl;
    }
 
    // Close our pipe handle
    CloseHandle(pipe);
 
    wcout << endl;
    wcout << endl;
    wcout << "Done." << endl;
 
    system("pause");
    return 0;
}
