// Win32UnmanagedLib.cpp : DLL 응용 프로그램을 위해 내보낸 함수를 정의합니다.
//

#include "stdafx.h"
#include "stdio.h"
#include "Win32UnmanagedLib.h"

DLLFunction int __stdcall addint(int n1, int n2)
{
	return n1 + n2;
}

DLLFunction int __stdcall addchar(char* s1, char* s2, char* added)
{
	sprintf_s(added,sizeof(added), "%s%s", s1, s2);
	return strlen(added);
}
