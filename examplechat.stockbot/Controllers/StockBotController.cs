using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examplechat.common.Models;
using examplechat.stockbot.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace examplechat.stockbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockBotController : ControllerBase
    {
        private IStockBotService StockBotService;

        public StockBotController(IStockBotService stockInfoDomain)
        {
            StockBotService = stockInfoDomain;
        }

        /// <summary>
        /// Bot Controller
        /// </summary>
        /// <param name="stock_code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStock")]
        public ActionResult<Stock> GetStock(string stock_code)
        {
            try
            {
                var result = StockBotService.GetStock(stock_code);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
