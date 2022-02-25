using AutoMapper;

using JedoxifyMart.Services.StandsAPI.DTOs;
using JedoxifyMart.Services.StandsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.StandsAPI.Data
{
    public class StandRepo : IStandRepo
    {

        private readonly AppDBContext _appDBContext;
        private IMapper _mapper;

        public StandRepo(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task<StandDto> GetStandById(int standId)
        {
            var stand = await _appDBContext.Stand
                .Include(one => one.StandDetails)
                    .ThenInclude(team => team.Product).FirstOrDefaultAsync(u => u.StandId == standId);

            return _mapper.Map<StandDto>(stand);

        }

        public bool SaveChanges()
        {
            return (_appDBContext.SaveChanges() >= 0);
        }

       public async Task<IEnumerable<StandDto>> GetAllStands()
        {
            List<Stand> standList = await _appDBContext.Stand.ToListAsync();
            List<StandDetails> standDetails = new List<StandDetails>();


            var player = await _appDBContext.Stand
                .Include(one => one.StandDetails)
                    .ThenInclude(team => team.Product)
                .ToListAsync();

            return _mapper.Map<List<StandDto>>(player);

        }

        public async Task<StandDto> CreateUpdateStand(StandDto standDto)
        {
            Stand stand = _mapper.Map<Stand>(standDto);

           // Method is not yet implemented

            return _mapper.Map<StandDto>(stand);
        }

        public Task<bool> DeleteStand(int standId)
        {
            throw new NotImplementedException();
        }
    }
}
