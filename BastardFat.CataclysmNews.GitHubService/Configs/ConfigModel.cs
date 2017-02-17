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


        public static ConfigModel GetFromFile() => Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(@"Configs\settings.json"));

    }
}
