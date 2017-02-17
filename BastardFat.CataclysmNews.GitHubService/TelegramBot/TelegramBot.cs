using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.CataclysmNews.GitHubService.TelegramBot
{
    public static class TelegramSender
    {
        private const long ID = 324396350;
        private static readonly string BotToken = File.ReadAllText(Configs.ConfigModel.Get.TelegramBotToken);

        private static Telegram.Bot.TelegramBotClient bot;

        static TelegramSender()
        {
            try
            {
                bot = new Telegram.Bot.TelegramBotClient(BotToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void Send(string message)
        {
            try
            {
                var t = bot.SendTextMessageAsync(ID, message).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
