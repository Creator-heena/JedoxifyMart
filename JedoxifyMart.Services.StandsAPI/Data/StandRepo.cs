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

            //check if product exists in database, if not create it!
            //var prodInDb = await _appDBContext.Products
            //    .FirstOrDefaultAsync(u => u.ProductId == cartDto.CartDetails.FirstOrDefault()
            //    .ProductId);
            //if (prodInDb == null)
            //{
            //    _appDBContext.Products.Add(cart.CartDetails.FirstOrDefault().Product);
            //    await _appDBContext.SaveChangesAsync();
            //}


            ////check if header is null
            //var cartHeaderFromDb = await _appDBContext.CartHeaders.AsNoTracking()
            //    .FirstOrDefaultAsync(u => u.UserId == cart.CartHeader.UserId);

            //if (cartHeaderFromDb == null)
            //{
            //    //create header and details
            //    _appDBContext.CartHeaders.Add(cart.CartHeader);
            //    await _appDBContext.SaveChangesAsync();
            //    cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
            //    cart.CartDetails.FirstOrDefault().Product = null;
            //    _appDBContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            //    await _appDBContext.SaveChangesAsync();
            //}
            //else
            //{
            //    //if header is not null
            //    //check if details has same product
            //    var cartDetailsFromDb = await _appDBContext.CartDetails.AsNoTracking().FirstOrDefaultAsync(
            //        u => u.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
            //        u.CartHeaderId == cartHeaderFromDb.CartHeaderId);

            //    if (cartDetailsFromDb == null)
            //    {
            //        //create details
            //        cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeaderFromDb.CartHeaderId;
            //        cart.CartDetails.FirstOrDefault().Product = null;
            //        _appDBContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            //        await _appDBContext.SaveChangesAsync();
            //    }
            //    else
            //    {
            //        //update the count / cart details
            //        cart.CartDetails.FirstOrDefault().Product = null;
            //        cart.CartDetails.FirstOrDefault().ProductCount += cartDetailsFromDb.ProductCount;
            //        cart.CartDetails.FirstOrDefault().CartDetailsId = cartDetailsFromDb.CartDetailsId;
            //        cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetailsFromDb.CartHeaderId;
            //        _appDBContext.CartDetails.Update(cart.CartDetails.FirstOrDefault());
            //        await _appDBContext.SaveChangesAsync();
            //    }
            //}

            return _mapper.Map<StandDto>(stand);
        }

        public Task<bool> DeleteStand(int standId)
        {
            throw new NotImplementedException();
        }
    }
}
