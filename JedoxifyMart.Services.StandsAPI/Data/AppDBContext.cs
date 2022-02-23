using JedoxifyMart.Services.StandsAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace JedoxifyMart.Services.StandsAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {

        }
        public DbSet<Stand> Stand { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<StandDetails> StandDetails { get; set; }
    }
}
