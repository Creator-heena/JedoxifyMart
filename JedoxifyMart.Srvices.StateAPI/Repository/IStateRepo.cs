using JedoxifyMart.Services.StateAPI.DTOs;

namespace JedoxifyMart.Services.StateAPI.Repository
{
    public interface IStateRepo
    {
        bool SaveChanges();      

        Task<StateDto> GetStateByTime();
        Task<string> GetCurrentState();
        Task<StateDto> UpdateState(StateDto state);

    
    }
}
