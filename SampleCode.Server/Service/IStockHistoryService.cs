using SampleCode.Server.Models;

namespace SampleCode.Server.Service
{
    /// <summary>
    /// Interface for Getting Stock Data - Business Layer
    /// </summary>
    public interface IStockHistoryService
    {
        /// <summary>
        /// Get Stock History by Ticker
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        public Task<List<Price>> GetStocksHistory(string ticker);
    }
}
