using Alex.Kingdee.Cloud.WebAPI.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdeeWebAPIdotNet
{
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        private K3CloudApiClient _client;
        private bool _isLogin = false;

        static Singleton()
        {
        }

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public string Login(string url, string dbid, string user, string pwd)
        {
            K3CloudApiClient client = new K3CloudApiClient(url);
            var loginResult = client.ValidateLogin(dbid, user, pwd, 2052);
            var resultType = JObject.Parse(loginResult)["LoginResultType"].Value<int>();
            if (resultType == 1)
            {
                _client = client;
                _isLogin = true;
            }
            return loginResult;
        }

        public void Logout()
        {
            if (_isLogin)
            {
                _client.Logout();
                _isLogin = false;
            }
        }

        public string Save(string formid, string data)
        {
            string ret = "";
            if (_isLogin)
            {
                ret = _client.Save(formid, data);
            }
            return ret;
        }

        public string Submit(string formid, string data)
        {
            string ret = "";
            if (_isLogin)
            {
                ret = _client.Submit(formid, data);
            }
            return ret;
        }

        public string Audit(string formid, string data)
        {
            string ret = "";
            if (_isLogin)
            {
                ret = _client.Audit(formid, data);
            }
            return ret;
        }

        public string UnAudit(string formid, string data)
        {
            string ret = "";
            if (_isLogin)
            {
                ret = _client.UnAudit(formid, data);
            }
            return ret;
        }

        public string Delete(string formid, string data)
        {
            string ret = "";
            if (_isLogin)
            {
                ret = _client.Delete(formid, data);
            }
            return ret;
        }
    }
}
