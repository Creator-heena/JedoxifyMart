using JedoxifyMart.Services.StandsAPI.Models;


namespace JedoxifyMart.Services.StandsAPI.Data
{
    public interface IStandRepo
    {
        bool SaveChanges();

        IEnumerable<Stand> GetAllStands();

        Stand GetStandById(int id);

        void CreateStand(Stand stand);
    }
}
