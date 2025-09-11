using Microsoft.EntityFrameworkCore;
using SampleCode.Server.Models;

namespace SampleCode.Server.Data
{
    public class StocksContext(IConfiguration configuration) : DbContext
    {
        private readonly IConfiguration _configuration = configuration;

        public DbSet<Price> Price { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection"); 
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}


