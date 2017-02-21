using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService.Configs
{
    internal class ConfigModel
    {
        public string ApiUrl { get; set; }
        public int RefreshPeriod { get; set; }
        public string OriginUrl { get; set; }
        public string ReferUrl { get; set; }
        public string RequestTemplateFile { get; set; }
        public string GitHubUser { get; set; }
        public string GitHubPasswordFile { get; set; }
        public string GitHubUserAgent { get; set; }
        public string SiteServerIp { get; set; }
        public int SiteServerPort { get; set; }
        public string TelegramBotToken { get; set; }

        public string TestApiUrl { get; set; } = "https://api.github.com/events";

        private static ConfigModel configs;
        public static ConfigModel Get
        {
            get
            {
                if(configs == null)
                    configs = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(@"Configs\settings.json"));
                return configs;
            }
        }

    }
}
