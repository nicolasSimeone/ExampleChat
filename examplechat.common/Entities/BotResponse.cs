using System;
namespace examplechat.common.Entities
{
    public class BotResponse
    {
        public bool IsSuccessful { get; set; }
        public bool Detected { get; set; }
        public string ErrorMessage { get; set; }
        public string Symbol { get; set; }
        public string Close { get; set; }
    }
}
