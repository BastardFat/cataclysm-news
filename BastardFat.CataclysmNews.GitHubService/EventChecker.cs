using BastardFat.CataclysmNews.GitHubService.Client;
using BastardFat.CataclysmNews.GitHubService.Serialization.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BastardFat.CataclysmNews.GitHubService
{
    public class EventChecker
    {
        public EventChecker(string apiUrl, int refreshPeriod)
        {
            ApiUrl = apiUrl;
            Timer t = new Timer(refreshPeriod);
            t.Elapsed += Refresh;
            
            t.Start();
           
        }

        public event Action<Event> IssuesEvent = delegate { };

        public event Action<Event> PullRequestEvent = delegate { };



        private void Refresh(object sender, ElapsedEventArgs ea)
        {
            var json = httpSender.SendGet(ApiUrl);
            var events = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Event>>(json)
                        .Where(e => (e.type == "IssuesEvent" || e.type == "PullRequestEvent") && e.created_at.Ticks > lastReceivedTime)
                        .ToList();

            foreach (var item in events.OrderBy(e => e.created_at))
            {
                lastReceivedTime = item.created_at.Ticks;
                if (item.type == "IssuesEvent") IssuesEvent.Invoke(item);
                if (item.type == "PullRequestEvent") PullRequestEvent.Invoke(item);
            }
        }

        private long lastReceivedTime = DateTime.UtcNow.Ticks;
        private string ApiUrl;
        private HttpSender httpSender = new HttpSender();

    }
}
