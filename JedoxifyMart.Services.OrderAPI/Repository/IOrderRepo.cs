using JedoxifyMart.Services.OrderAPI.Models;

namespace JedoxifyMart.Services.OrderAPI.Repository
{
    public interface IOrderRepo
    {

        Task<bool> AddOrder(OrderHeader orderHeader);


    }
}
