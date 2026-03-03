#include <Windows.h>

static void foo()
{
	OutputDebugStringA("Hello, World!\n");
}

int WINAPI WinMain
(
	_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPSTR lpCmdLine,
	_In_ int nCmdShow
)
{
	char unsigned Test;

	Test = 255;
	Test = Test + 2;

	foo();
}
