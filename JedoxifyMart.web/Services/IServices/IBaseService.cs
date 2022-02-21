using JedoxifyMart.web.Models;

namespace JedoxifyMart.web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync <T>(ApiRequest apiRequest);

    }
}
