using JedoxifyMart.Services.StandsAPI.DTOs;
using JedoxifyMart.Services.StandsAPI.Models;


namespace JedoxifyMart.Services.StandsAPI.Data
{
    public interface IStandRepo
    {
        bool SaveChanges();

        Task<IEnumerable<StandDto>> GetAllStands();

        Task<StandDto> GetStandById(int standId);

        Task<StandDto> CreateUpdateStand(StandDto standDto);

        Task<bool> DeleteStand(int standId);

    }
}

