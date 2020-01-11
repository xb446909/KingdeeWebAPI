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

        private string JsonToxml(string s, string r = "root")
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

        private string XmlTojson(string s, string r = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>")
        {

            s = s.Replace(r, "");
            var doc = new XmlDocument();
            doc.LoadXml(s);
            return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
        }
    }
}
