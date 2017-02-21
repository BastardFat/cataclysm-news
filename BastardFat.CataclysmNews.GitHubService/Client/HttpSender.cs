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
            http_request.Headers.Add("Accept-Charset: utf-8");
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

        public string SendViaTcp(string address, int port, string message)
        {
            try
            {
                byte[] data = Encoding.Default.GetBytes(PrepareRequest(message));
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
                        respStr += Encoding.Default.GetString(data, 0, rec);
                    } while (rec == data.Length);
                    return respStr;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ForegroundColor = ConsoleColor.Gray;
                throw;
            }
        }

        private string PrepareRequest(string body) =>
            File.ReadAllText(ConfigModel.Get.RequestTemplateFile)
                .Replace("{ORIGINURL}", ConfigModel.Get.OriginUrl)
                .Replace("{REFERURL}", ConfigModel.Get.ReferUrl)
                .Replace("{CONTENTLENGTH}", body.Length.ToString())
                .Replace("{REQUESTBODY}", body);


    }
}
