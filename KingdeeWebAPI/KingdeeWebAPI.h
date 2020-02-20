#pragma once

void __stdcall Test();
void __stdcall SetMode(int nMode);
void __stdcall Login(const char* url, const char* dbid, const char* user, const char* pwd, char* result);
void __stdcall Logout();
void __stdcall Save(char* formid, char* data, char* result);
void __stdcall Submit(char* formid, char* data, char* result);
void __stdcall Audit(char* formid, char* data, char* result);
void __stdcall UnAudit(char* formid, char* data, char* result);
void __stdcall Delete(char* formid, char* data, char* result);
