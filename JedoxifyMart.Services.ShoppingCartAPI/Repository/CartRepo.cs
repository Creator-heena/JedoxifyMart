using AutoMapper;
using JedoxifyMart.Services.ShoppingCart.Data;
using JedoxifyMart.Services.ShoppingCartAPI.DTOs;
using JedoxifyMart.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.ShoppingCartAPI.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly AppDBContext _appDBContext;
        private  IMapper _mapper;

        public CartRepo(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }
        public async Task<bool> ClearCart(string userId)
        {
            var cartHeaderFromDb = await _appDBContext.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId);
            if (cartHeaderFromDb != null)
            {
                _appDBContext.CartDetails
                    .RemoveRange(_appDBContext.CartDetails.Where(u => u.CartHeaderId == cartHeaderFromDb.CartHeaderId));
                _appDBContext.CartHeaders.Remove(cartHeaderFromDb);
                await _appDBContext.SaveChangesAsync();
                return true;

            }
            return false;

        }

        public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {

            Cart cart = _mapper.Map<Cart>(cartDto);

            //check if product exists in database, if not create it!
            var prodInDb = await _appDBContext.Products
                .FirstOrDefaultAsync(u => u.ProductId == cartDto.CartDetails.FirstOrDefault()
                .ProductId);
            if (prodInDb == null)
            {
                _appDBContext.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await _appDBContext.SaveChangesAsync();
            }


            //check if header is null
            var cartHeaderFromDb = await _appDBContext.CartHeaders.AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == cart.CartHeader.UserId);

            if (cartHeaderFromDb == null)
            {
                //create header and details
                _appDBContext.CartHeaders.Add(cart.CartHeader);
                await _appDBContext.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Product = null;
                _appDBContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _appDBContext.SaveChangesAsync();
            }
            else
            {
                //if header is not null
                //check if details has same product
                var cartDetailsFromDb = await _appDBContext.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    u => u.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    u.CartHeaderId == cartHeaderFromDb.CartHeaderId);

                if (cartDetailsFromDb == null)
                {
                    //create details
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _appDBContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _appDBContext.SaveChangesAsync();
                }
                else
                {
                    //update the count / cart details
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().ProductCount += cartDetailsFromDb.ProductCount;
                    cart.CartDetails.FirstOrDefault().CartDetailsId = cartDetailsFromDb.CartDetailsId;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                    _appDBContext.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _appDBContext.SaveChangesAsync();
                }
            }

            return _mapper.Map<CartDto>(cart);

        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _appDBContext.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId)
            };

            cart.CartDetails = _appDBContext.CartDetails
                .Where(u => u.CartHeaderId == cart.CartHeader.CartHeaderId).Include(u => u.Product);

            return _mapper.Map<CartDto>(cart);


        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            try
            {
                CartDetails cartDetails = await _appDBContext.CartDetails
                    .FirstOrDefaultAsync(u => u.CartDetailsId == cartDetailsId);

                int totalCountOfCartItems = _appDBContext.CartDetails
                    .Where(u => u.CartHeaderId == cartDetails.CartHeaderId).Count();

                _appDBContext.CartDetails.Remove(cartDetails);
                if (totalCountOfCartItems == 1)
                {
                    var cartHeaderToRemove = await _appDBContext.CartHeaders
                        .FirstOrDefaultAsync(u => u.CartHeaderId == cartDetails.CartHeaderId);

                    _appDBContext.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
