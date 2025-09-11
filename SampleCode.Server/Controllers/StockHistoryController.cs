using Microsoft.AspNetCore.Mvc;
using SampleCode.Server.Models;
using SampleCode.Server.Service;
using System.ComponentModel.DataAnnotations;

namespace SampleCode.Server.Controllers
{
    /// <summary>
    /// Stock History Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StockHistoryController : ControllerBase
    {
        private readonly ILogger<StockHistoryController> _logger;
        private IStockHistoryService _stockHistoryService;

        public StockHistoryController(ILogger<StockHistoryController> logger, IStockHistoryService stockHistoryService)
        {
            _logger = logger; 
            _stockHistoryService = stockHistoryService;
        }

        /// <summary>
        /// Get endpoint for retrieving data
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Price> Get([Required] string ticker)
        {
            if (string.IsNullOrWhiteSpace(ticker))
            {
                _logger.LogError("Ticker not provided. Value: {1}", ticker);
                return Enumerable.Empty<Price>();
            }

            _logger.LogInformation("Getting ticket data for {1}", ticker); 
            var results = _stockHistoryService.GetStocksHistory(ticker).Result;
            return results;
        }

    }
}
