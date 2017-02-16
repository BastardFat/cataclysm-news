using System;
using System.IO;
using System.Net;
using System.Text;

namespace BastardFat.CataclysmNews.GitHubService.Client
{
    public class HttpSender
    {
        public string SendGet(string url)
        {
            HttpWebRequest http_request = WebRequest.CreateHttp(url);
            http_request.Method = "GET";
            http_request.UserAgent = "Test-app";
            http_request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes("BastardFat" + ":" + "t367830t")));

            using (var response = (HttpWebResponse) http_request.GetResponse())
            {
                string responseText;
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    responseText = reader.ReadToEnd();
                return responseText;
            }
        }

    }
}
