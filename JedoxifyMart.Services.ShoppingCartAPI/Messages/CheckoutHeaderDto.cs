using JedoxifyMart.Services.ShoppingCartAPI.DTOs;

namespace JedoxifyMart.Services.ShoppingCartAPI.Messages
{
    public class CheckoutHeaderDto
    {
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }

        public double OrderTotal { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CartTotalItems { get; set; }

        public IEnumerable<CartDetailsDto>  CartDetails { get; set; }


    }
}
