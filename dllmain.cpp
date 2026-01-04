#include <windows.h>

#define NSVG_BUILD
#define NSVG_DLL
#define NANOSVG_ALL_COLOR_KEYWORDS	// Include full list of color keywords.
#define NANOSVG_IMPLEMENTATION		// Expands implementation
#include "nanosvg.h"
#include "nanosvgrast.h"

// BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
// {
//     switch (ul_reason_for_call)
//     {
//     case DLL_PROCESS_ATTACH:
//     case DLL_THREAD_ATTACH:
//     case DLL_THREAD_DETACH:
//     case DLL_PROCESS_DETACH:
//         break;
//     }
// 	
//     return TRUE;
// }
//
