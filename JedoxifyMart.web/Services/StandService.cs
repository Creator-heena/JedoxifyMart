using JedoxifyMart.web.Models;
using JedoxifyMart.web.Services.IServices;

namespace JedoxifyMart.web.Services
{
    public class StandService : BaseService, IStandService
    {
        private readonly IHttpClientFactory _clientFactory;

        public StandService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetAllStandsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Data = "",
                Url = StaticDetails.StandAPIBase + "/api/stands",
                AccessToken = ""

            });
        }
    }
}
