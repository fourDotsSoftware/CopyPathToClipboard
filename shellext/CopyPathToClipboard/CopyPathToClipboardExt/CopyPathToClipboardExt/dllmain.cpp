// dllmain.cpp : Implementation of DllMain.

#include "stdafx.h"
#include "Resource.h"
#include "CopyPathToClipboardExt_i.h"
#include "dllmain.h"

CCopyPathToClipboardExtModule _AtlModule;

// DLL Entry Point
extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
	return _AtlModule.DllMain(dwReason, lpReserved); 
}
