using JedoxifyMart.Services.OrderAPI.Data;
using JedoxifyMart.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.OrderAPI.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly DbContextOptions<AppDBContext> _dbContext;

        public OrderRepo(DbContextOptions<AppDBContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public  async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            await using var _database = new AppDBContext(_dbContext);
            _database.OrderHeaders.Add(orderHeader);
            await _database.SaveChangesAsync();
            return true;
        }
    }
}
