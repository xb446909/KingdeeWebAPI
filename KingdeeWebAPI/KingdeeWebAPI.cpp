#include "pch.h"

#include "KingdeeWebAPI.h"


#ifdef _DEBUG
#using "..\\KingdeeWebAPIdotNet\\bin\\Debug\\KingdeeWebAPIdotNet.dll"
#endif // _DEBUG

using namespace KingdeeWebAPIdotNet;

void __stdcall Test()
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	kingdee->Test();
}