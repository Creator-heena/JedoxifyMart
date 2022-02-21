using JedoxifyMart.Services.StandsAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace JedoxifyMart.Services.StandsAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base (opt)
            {

            }
        public DbSet<Stand> Stands { get; set; }
    }
}
