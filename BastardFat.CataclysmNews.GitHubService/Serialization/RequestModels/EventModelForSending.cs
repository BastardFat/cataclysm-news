using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService.Serialization.RequestModels
{
    public class EventModelForSending
    {
        public string title { get; set; }
        public string username { get; set; }
        public string avatar_url { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public string html { get; set; }
    }
}
