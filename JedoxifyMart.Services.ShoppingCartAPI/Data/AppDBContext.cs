using JedoxifyMart.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.ShoppingCart.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

        public DbSet<CartHeader> CartHeaders { get; set; }
    }
}
