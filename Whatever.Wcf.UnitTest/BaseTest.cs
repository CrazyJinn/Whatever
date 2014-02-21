using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Whatever.Wcf.UnitTest
{
    public class BaseTest
    {
        public static void Post(string url, string message) {
            
            byte[] bs = Encoding.ASCII.GetBytes(message);

            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.ContentType = "application/json";
            req.Method = "POST";
            req.ContentLength = bs.Length;
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(bs, 0, bs.Length);
            reqStream.Close();

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            StreamReader io = new StreamReader(resp.GetResponseStream());
            string str = io.ReadToEnd();

            Console.Write(str);
        }
    }
}
