using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SampleCode.Server.Controllers;
using SampleCode.Server.Models;
using SampleCode.Server.Service;

namespace SampleCode.ServerTests
{
    [TestClass]
    public sealed class StockHistoryControllerTests
    {
        [TestMethod]
        public void GetMethodProcessItemFromService()
        {
            // Arrange
            var mockProductService = new Mock<IStockHistoryService>();
            var mockLoggerService = new Mock<Microsoft.Extensions.Logging.ILogger<StockHistoryController>>();
            var expectedProducts = new List<Price> { new Price { Id = 1, Ticker = "Test Product" } };
            mockProductService.Setup(service => service.GetStocksHistory(It.IsAny<string>())).Returns(Task.FromResult(expectedProducts));

            var controller = new StockHistoryController(mockLoggerService.Object, mockProductService.Object);

            // Act
            var result = controller.Get("myTicker");

            // Assert
            Assert.AreEqual(expectedProducts.Count, result.Count());
            Assert.AreEqual(expectedProducts.First().Ticker, result.First().Ticker);
        }
    }
}
