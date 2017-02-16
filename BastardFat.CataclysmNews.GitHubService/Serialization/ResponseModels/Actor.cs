using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService.Serialization.ResponseModels
{
    public class Actor
    {
        public int id { get; set; }
        public string login { get; set; }
        public string avatar_url { get; set; }
    }
}
