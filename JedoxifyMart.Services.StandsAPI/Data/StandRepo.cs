using JedoxifyMart.Services.StandsAPI.Models;

namespace JedoxifyMart.Services.StandsAPI.Data
{
    public class StandRepo : IStandRepo
    {
        private readonly AppDBContext _context;
        public StandRepo(AppDBContext context)
        {
            _context = context;
        }
 
        public void CreateStand(Stand stand)
        {
            if (stand == null)
            {
                throw new ArgumentNullException(nameof(stand));
            }
            _context.Stands.Add(stand);
        }

        public IEnumerable<Stand> GetAllStands()
        {
            return _context.Stands.ToList();
        }

   
        public Stand GetStandById(int id)
        {
            return _context.Stands.FirstOrDefault(p => p.StandId == id);
        }

          public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
