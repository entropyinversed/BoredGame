#include <Windows.h>

struct projectile
{
	char unsigned IsThisOnFire;
	int Damage;
	int ParticlePerSecond;
	int HowManyCooks;
};

int WINAPI WinMain
(
	_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPSTR lpCmdLine,
	_In_ int nCmdShow
)
{
	projectile Test{};

	int Size = sizeof(Test);

	Test.IsThisOnFire = 1;
	Test.Damage = 1;
	Test.ParticlePerSecond = 1;
	Test.HowManyCooks = 1;

	int InttedAddress = int(& Test);
	projectile* ProjectilePointer = &Test;
	short *MrPointer = (short *) & Test;
}
