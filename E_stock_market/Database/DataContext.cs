using E_stock_market.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace E_stock_market.Database
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Cdata> CD { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<loginuser> userdata { get; set; }


    }
}
