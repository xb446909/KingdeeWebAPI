using Alex.Kingdee.Cloud.WebAPI.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KingdeeWebAPIdotNet
{
    public class KingdeeWebAPI
    {
        

        public void Test()
        {
            K3CloudApiClient client = new K3CloudApiClient("http://fin.puruiit.cn:58888/K3Cloud/");
            var loginResult = client.ValidateLogin("5def4fed400b95", "倚和测试", "123456", 2052);
            Console.WriteLine(loginResult);
            client.Logout();
        }

        public void SetMode(int nMode)
        {
            Singleton.Instance.SetMode(nMode);
        }

        public string Login(string url, string dbid, string user, string pwd)
        {
            return Singleton.Instance.Login(url, dbid, user, pwd);
        }

        public void Logout()
        {
            Singleton.Instance.Logout();
        }

        public string Save(string formid, string data)
        {
            return Singleton.Instance.Save(formid, data);
        }

        public string Submit(string formid, string data)
        {
            return Singleton.Instance.Submit(formid, data);
        }

        public string Audit(string formid, string data)
        {
            return Singleton.Instance.Audit(formid, data);
        }

        public string UnAudit(string formid, string data)
        {
            return Singleton.Instance.UnAudit(formid, data);
        }

        public string Delete(string formid, string data)
        {
            return Singleton.Instance.Delete(formid, data);
        }

        
    }
}
