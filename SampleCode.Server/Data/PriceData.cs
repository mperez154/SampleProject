using Microsoft.EntityFrameworkCore;
using SampleCode.Server.Models;

namespace SampleCode.Server.Data
{
    public class PriceData : IPriceData
    {
        private readonly StocksContext _stocksContext;
        private readonly ILogger<PriceData> _logger;
        private readonly IConfiguration _configuration; 

        public PriceData(StocksContext stocksContext, ILogger<PriceData> logger, IConfiguration configuration)
        {
            _stocksContext = stocksContext;
            _logger = logger; 
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<List<Price>> GetStockPrices(string Ticker)
        {
            var query = _stocksContext.Price.Where(x => x.Date >= DateTime.Now.AddDays(-100) && x.Ticker == Ticker).OrderByDescending(x => x.Close);

            if ("debug".Equals(_configuration["Logging:LogLevel:Microsoft.EntityFrameworkCore.Database.Command"].ToLower()))
            {
                _logger.LogInformation(query.ToQueryString());
            }
            
            return await Task.FromResult(query.ToList());
        }
    }
}
