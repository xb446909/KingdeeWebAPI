#include "pch.h"

#include "KingdeeWebAPI.h"
#include <string>  
#include <msclr/marshal_cppstd.h>

#ifdef _DEBUG
#using "..\\Debug\\KingdeeWebAPIdotNet.dll"
#else
#using "..\\Release\\KingdeeWebAPIdotNet.dll"
#endif // _DEBUG

using namespace msclr::interop;
using namespace KingdeeWebAPIdotNet;

void __stdcall Test()
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	kingdee->Test();
}

void __stdcall Login(const char* url, const char* dbid, const char* user, const char* pwd, char* result)
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	System::String^ ret = kingdee->Login(gcnew System::String(url), gcnew System::String(dbid), gcnew System::String(user), gcnew System::String(pwd));
	std::string szRet = marshal_as<std::string>(ret);
	strcpy(result, szRet.c_str());
}

void __stdcall Logout()
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	kingdee->Logout();
}

void __stdcall Save(char* formid, char* data, char* result)
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	System::String^ ret = kingdee->Save(gcnew System::String(formid), gcnew System::String(data));
	std::string szRet = marshal_as<std::string>(ret);
	strcpy(result, szRet.c_str());
}

void __stdcall Submit(char* formid, char* data, char* result)
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	System::String^ ret = kingdee->Submit(gcnew System::String(formid), gcnew System::String(data));
	std::string szRet = marshal_as<std::string>(ret);
	strcpy(result, szRet.c_str());
}

void __stdcall Audit(char* formid, char* data, char* result)
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	System::String^ ret = kingdee->Audit(gcnew System::String(formid), gcnew System::String(data));
	std::string szRet = marshal_as<std::string>(ret);
	strcpy(result, szRet.c_str());
}

void __stdcall UnAudit(char* formid, char* data, char* result)
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	System::String^ ret = kingdee->UnAudit(gcnew System::String(formid), gcnew System::String(data));
	std::string szRet = marshal_as<std::string>(ret);
	strcpy(result, szRet.c_str());
}

void __stdcall Delete(char* formid, char* data, char* result)
{
	KingdeeWebAPIdotNet::KingdeeWebAPI^ kingdee = gcnew KingdeeWebAPIdotNet::KingdeeWebAPI();
	System::String^ ret = kingdee->Delete(gcnew System::String(formid), gcnew System::String(data));
	std::string szRet = marshal_as<std::string>(ret);
	strcpy(result, szRet.c_str());
}
