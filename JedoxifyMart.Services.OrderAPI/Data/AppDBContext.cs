using JedoxifyMart.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.OrderAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
