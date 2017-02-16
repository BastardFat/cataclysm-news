using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService.Serialization.ResponseModels
{
    public class Event
    {
        public string id { get; set; }
        public string type { get; set; }
        public DateTime created_at { get; set; }
        public Actor actor { get; set; }
        public Payload payload { get; set; }
    }
}
