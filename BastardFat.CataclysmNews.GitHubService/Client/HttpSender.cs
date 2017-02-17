using BastardFat.CataclysmNews.GitHubService.Configs;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BastardFat.CataclysmNews.GitHubService.Client
{
    public class HttpSender
    {
        public string SendGet(string url)
        {
            HttpWebRequest http_request = WebRequest.CreateHttp(url);
            http_request.Method = "GET";
            http_request.UserAgent = ConfigModel.Get.GitHubUserAgent;
            http_request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(ConfigModel.Get.GitHubUser + ":" + File.ReadAllText(ConfigModel.Get.GitHubPasswordFile))));

            using (var response = (HttpWebResponse) http_request.GetResponse())
            {
                string responseText;
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    responseText = reader.ReadToEnd();
                return responseText;
            }
        }

        static string SendViaTcp(string address, int port, string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            using (TcpClient client = new TcpClient(address, 80))
            using (var stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);
                data = new byte[256];
                var respStr = String.Empty;
                int rec;
                do
                {
                    rec = stream.Read(data, 0, data.Length);
                    respStr += Encoding.ASCII.GetString(data, 0, rec);
                } while (rec == data.Length);
                return respStr;
            }
        }

    }
}
