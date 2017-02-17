using BastardFat.CataclysmNews.GitHubService.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService
{
    class Program
    {
        static void Main(string[] args)
        {
            EventChecker EventChecker = new EventChecker("https://api.github.com/events", ConfigModel.Get.RefreshPeriod);
            EventChecker.IssuesEvent += EventChecker_IssuesEvent;
            EventChecker.PullRequestEvent += EventChecker_PullRequestEvent;
            while (Console.ReadLine().ToLower() != "stop") Console.WriteLine("Type \"stop\" to stop service");
        }

        private static void EventChecker_IssuesEvent(Serialization.ResponseModels.Event obj)
        {
            Console.WriteLine("Issue");
        }

        private static void EventChecker_PullRequestEvent(Serialization.ResponseModels.Event obj)
        {
            Console.WriteLine("PR");
        }


    }
}
