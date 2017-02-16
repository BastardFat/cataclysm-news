using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService.Serialization.ResponseModels
{
    public class Comment
    {
        public string body { get; set; }
        public Actor user { get; set; }
    }
}
