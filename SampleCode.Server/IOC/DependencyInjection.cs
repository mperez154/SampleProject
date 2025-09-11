using Microsoft.EntityFrameworkCore;
using SampleCode.Server.Data;
using SampleCode.Server.Service;

namespace SampleCode.Server.IOC;
/// <summary>
/// Dependency Injection for Back End Service
/// </summary>
public class DependencyInjection
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// DI Setup
    /// </summary>
    /// <param name="configuration"></param>
    public DependencyInjection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Injecting Dependencies Into App
    /// </summary>
    /// <param name="services"></param>
    public void InjectDependencies(IServiceCollection services)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                .AddConsole(); // Or other logging providers like Debug, File, etc.
        });

        string connectionString = _configuration.GetValue<string>("SqlConnectionString");
        services.AddDbContext<StocksContext>(
            options => options.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));

        services.AddScoped<IPriceData, PriceData>();
        services.AddScoped<IStockHistoryService, StockHistoryService>();
    }
}