using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService.Serialization.ResponseModels
{
    public class Payload
    {
        public string action { get; set; }
        public PullRequest pull_request { get; set; }
        public Issue issue { get; set; }
        public Comment comment { get; set; }
    }
}
