using JedoxifyMart.Services.ProductsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.ProductsAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt) 
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
