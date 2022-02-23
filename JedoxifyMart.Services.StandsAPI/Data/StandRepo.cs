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
        //public async Task<StandDto> CreateStand(StandDto standDto)
        //{
        //    Stand stand = _mapper.Map<Stand>(standDto);
        //    var prodInDb = await _appDBContext.Products
        //    .FirstOrDefaultAsync(u => u.ProductId == standDto.Product
        //    .ProductId);

        //    stand.Product = standDto.Product;
        //    _appDBContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
        //    await _appDBContext.SaveChangesAsync();
        //}


        //public IEnumerable<Stand> GetAllStands()
        //{
        //    return _context.Stands.ToList();
        //}

   
        //public Stand GetStandById(int id)
        //{
        //    return _context.Stands.FirstOrDefault(p => p.StandId == id);
        //}

        public async Task<StandDto> GetStandById(int standId)
        {
            var stand = await _appDBContext.Stand.FirstOrDefaultAsync(u => u.StandId == standId);
            

            //stand.Products = _appDBContext.Products
            //    .Where(u => u.ProductId == stand.Product.ProductId);

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
    }
}
