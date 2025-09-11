using SampleCode.Server.Models;

namespace SampleCode.Server.Data
{
    /// <summary>
    /// Interface for getting price data from db
    /// </summary>
    public interface IPriceData
    {
        /// <summary>
        /// Data Layer - Gets Stock Prices by Ticker
        /// </summary>
        /// <param name="Ticker"></param>
        /// <returns></returns>
        public Task<List<Price>> GetStockPrices(string Ticker);
    }
}
