// Tester.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include "..\\KingdeeWebAPI\KingdeeWebAPI.h"

#ifdef _DEBUG
#pragma comment(lib, "..\\Debug\\KingdeeWebAPI.lib")
#else
#pragma comment(lib, "..\\Release\\KingdeeWebAPI.lib")
#endif // _DEBUG


int main()
{
    //Test();

    char szResult[2048] = { 0 };
    Login("http://fin.puruiit.cn:58888/K3Cloud/", "5def4fed400b95", "倚和测试", "123456", szResult);

    std::cout << szResult << std::endl;

    Logout();
}
