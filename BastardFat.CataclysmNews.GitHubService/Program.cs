using BastardFat.CataclysmNews.GitHubService.Client;
using BastardFat.CataclysmNews.GitHubService.Configs;
using BastardFat.CataclysmNews.GitHubService.Serialization.RequestModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService
{
    class Program
    {
        static void Main(string[] args)
        {
            EventChecker EventChecker = new EventChecker(ConfigModel.Get.ApiUrl, ConfigModel.Get.RefreshPeriod);
            EventChecker.IssuesEvent += EventChecker_IssuesEvent;
            EventChecker.PullRequestEvent += EventChecker_PullRequestEvent;
            while (Console.ReadLine().ToLower() != "stop") Console.WriteLine("Type \"stop\" to stop service");
        }

        private static HttpSender Sender = new HttpSender();

        private static void EventChecker_IssuesEvent(Serialization.ResponseModels.Event e)
        {
            Console.WriteLine($"{e.type} - {e.payload.issue.title}");
            var model = new EventModelForSending()
            {
                avatar_url = e.actor.avatar_url,
                html = Markdig.Markdown.ToHtml(e.payload.issue.body),
                label = e.payload.action,
                title = e.payload.issue.title,
                type = "Issue",
                username = e.actor.login
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model, new Newtonsoft.Json.JsonSerializerSettings() { StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.EscapeNonAscii });

            Sender.SendViaTcp(ConfigModel.Get.SiteServerIp, ConfigModel.Get.SiteServerPort, json);
            TelegramBot.TelegramSender.Send($"Issue ({e.payload.action}) \"{e.payload.issue.title}\" from {e.actor.login}");
        }

        private static void EventChecker_PullRequestEvent(Serialization.ResponseModels.Event e)
        {

            Console.WriteLine($"{e.type} - {e.payload.pull_request.title}");
            var model = new EventModelForSending()
            {
                avatar_url = e.actor.avatar_url,
                html = $"<span style=\"color:green; \">++{e.payload.pull_request.additions}</span> <span style=\"color: red; \">--{e.payload.pull_request.deletions}</span> in <b>{e.payload.pull_request.commits}</b> commit(s). <b>{e.payload.pull_request.changed_files}</b> file(s) changed <br /> <a href=\"{e.payload.pull_request.html_url}\">Github link</a>" 
                    + Markdig.Markdown.ToHtml(e.payload.pull_request.body ?? ""),
                label = e.payload.action,
                title = e.payload.pull_request.title,
                type = "Pull Request",
                username = e.actor.login
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model, new Newtonsoft.Json.JsonSerializerSettings() { StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.EscapeNonAscii });

            Sender.SendViaTcp(ConfigModel.Get.SiteServerIp, ConfigModel.Get.SiteServerPort, json);
            TelegramBot.TelegramSender.Send($"Pull Request ({e.payload.action}) \"{e.payload.pull_request.title}\" from {e.actor.login}");
        }


    }
}
