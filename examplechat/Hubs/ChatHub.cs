using System;
using System.Threading.Tasks;
using examplechat.Models;
using examplechat.Services;
using Microsoft.AspNetCore.SignalR;

namespace examplechat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IStockBotService StockBotService;

        public ChatHub(IStockBotService _stockBotService)
        {
            StockBotService = _stockBotService;
        }

        /// <summary>
        /// Message handling logic
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
            var botResponse = StockBotService.BotDetection(message.Text);
            if (botResponse.Detected)
                if (botResponse.IsSuccessful)
                    await Clients.All.SendAsync("receiveMessage", StockBotMessage($"{botResponse.Symbol} quote is {botResponse.Close} per share"));
                else
                    await Clients.All.SendAsync("receiveMessage", StockBotMessage($"We have a problem. { botResponse.ErrorMessage }"));
        }

        /// <summary>
        /// Create a Bot message
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal Message StockBotMessage(string text)
        {
            return new Message
            {
                UserName = "StockBot",
                Text = text,
                When = DateTime.Now
            };
        }
    }
}
