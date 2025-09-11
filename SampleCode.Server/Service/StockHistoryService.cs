
using SampleCode.Server.Data;
using SampleCode.Server.Models;

namespace SampleCode.Server.Service
{
    public class StockHistoryService : IStockHistoryService
    {
        private readonly ILogger<StockHistoryService> _logger;
        private readonly IPriceData _priceData; 

        public StockHistoryService(ILogger<StockHistoryService> logger, IPriceData priceData)
        {
            _logger = logger; 
            _priceData = priceData;
        }

        public async Task<List<Price>> GetStocksHistory(string ticker)
        {
            _logger.LogInformation("Process data as needed"); 
            var result = await _priceData.GetStockPrices(ticker);
            return result; 
        }
    }
}
