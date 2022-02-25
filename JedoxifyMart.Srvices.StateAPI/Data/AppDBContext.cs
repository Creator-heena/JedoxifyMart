using JedoxifyMart.Services.StateAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.StateAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {

        }
        public DbSet<State> states { get; set; }
    }
}
