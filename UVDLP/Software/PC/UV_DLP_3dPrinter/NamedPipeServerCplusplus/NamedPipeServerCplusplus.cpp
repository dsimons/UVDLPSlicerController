// http://www.avid-insight.co.uk/2012/03/introduction-to-win32-named-pipes-cpp/

#include "stdafx.h"
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	BOOL result;

    wcout << "Creating an instance of a named pipe..." << endl;
 
    // Create a pipe to send data
    HANDLE pipe = CreateNamedPipe(
        L"\\\\.\\pipe\\3dPrinter", // name of the pipe
        PIPE_ACCESS_DUPLEX,
        PIPE_TYPE_BYTE, // send data as a byte stream
        1, // only allow 1 instance of this pipe
        0, // no outbound buffer
        0, // no inbound buffer
        0, // use default wait time
        NULL // use default security attributes
    );
 
    if (pipe == NULL || pipe == INVALID_HANDLE_VALUE) {
        wcout << "Failed to create outbound pipe instance.";
        // look up error code here using GetLastError()
        system("pause");
        return 1;
    }
 
    wcout << "Waiting for a client to connect to the pipe..." << endl;
 
    // This call blocks until a client process connects to the pipe
    result = ConnectNamedPipe(pipe, NULL);
    if (!result) {
        wcout << "Failed to make connection on named pipe." << endl;
        // look up error code here using GetLastError()
        CloseHandle(pipe); // close the pipe
        system("pause");
        return 1;
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

	wcout << "Sending data to pipe..." << endl;
 
    // This call blocks until a client process reads all the data
    const wchar_t *data = L"*** Hello From C++ server ***\n";
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
 
    // Close the pipe (automatically disconnects client too)
    CloseHandle(pipe);
 
    wcout << endl;
    wcout << endl;
    wcout << "Done." << endl;
 
    system("pause");
    return 0;
}

