using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService.Serialization.ResponseModels
{
    public class Issue
    {
        public string title { get; set; }
        public string body { get; set; }
        public Actor user { get; set; }
    }
}
