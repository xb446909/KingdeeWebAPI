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
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        private K3CloudApiClient _client;
        private bool _isLogin = false;
        private int _mode = 0;

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

        public void SetMode(int mode)
        {
            _mode = mode;
        }

        public string Login(string url, string dbid, string user, string pwd)
        {
            string loginResult;
            K3CloudApiClient client;
            try
            {
                client = new K3CloudApiClient(url);
                loginResult = client.ValidateLogin(dbid, user, pwd, 2052);
            }
            catch (Exception ex)
            {
                WebException webException = new WebException();
                webException.LoginResultType = -1;
                webException.Message = ex.Message;
                if (_mode != 0)
                {
                    return JsonToXml(JsonConvert.SerializeObject(webException));
                }
                return JsonConvert.SerializeObject(webException);
            }
            var resultType = JObject.Parse(loginResult)["LoginResultType"].Value<int>();
            if (resultType == 1)
            {
                _client = client;
                _isLogin = true;
            }
            if (_mode != 0)
            {
                return JsonToXml(loginResult);
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
            if (_mode != 0)
            {
                return JsonToXml(ret);
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
            if (_mode != 0)
            {
                return JsonToXml(ret);
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
            if (_mode != 0)
            {
                return JsonToXml(ret);
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
            if (_mode != 0)
            {
                return JsonToXml(ret);
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
            if (_mode != 0)
            {
                return JsonToXml(ret);
            }
            return ret;
        }

        private string JsonToXml(string s, string r = "root")
        {
            var doc = JsonConvert.DeserializeXmlNode(s, r);

            using (var stream = new MemoryStream())
            {
                var writer = new XmlTextWriter(stream, null) { Formatting = System.Xml.Formatting.Indented };
                doc.Save(writer);

                using (var sr = new StreamReader(stream, Encoding.UTF8))
                {
                    stream.Position = 0;
                    return sr.ReadToEnd();
                }
            }
        }

        private string XmlToJson(string s, string r = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>")
        {

            s = s.Replace(r, "");
            var doc = new XmlDocument();
            doc.LoadXml(s);
            return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
        }
    }

    public class WebException
    {
        public string Message { get; set; }
        public int LoginResultType { get; set; }
    }
}

