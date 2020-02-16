using System;
using examplechat.common.Entities;

namespace examplechat.Services
{
    public interface IStockBotService
    {
        BotResponse BotDetection(string message);
    }
}
