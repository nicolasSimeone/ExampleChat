using System;
using examplechat.common.Models;

namespace examplechat.stockbot.Services
{
    public interface IStockBotService
    {
        Stock GetStock(string stock_code);
    }
}
