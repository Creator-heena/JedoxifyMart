using JedoxifyMart.web.Models;
namespace JedoxifyMart.web.Services.IServices
{
    public interface IStandService
    {
        Task<T> GetAllStandsAsync<T>();
    }
}
