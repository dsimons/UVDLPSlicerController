// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>
#include <string.h>
#include <stdio.h>
#include <stddef.h>
// erforderlich für MessageBox
extern int WINAPI WinMain ( HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR szComdLine, int iCmdShow);
