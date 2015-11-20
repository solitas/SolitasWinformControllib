#pragma once

#ifndef WIN32_UNMANAGED_LIB_EXPORT
	#define	DLLFunction __declspec(dllexport)
#else
	#define	DLLFunction __declspec(dllimport)
#endif


extern "C" {
	DLLFunction int __stdcall addint(int n1, int n2);
	DLLFunction int __stdcall addchar(char* s1, char* s2, char* added);
}
