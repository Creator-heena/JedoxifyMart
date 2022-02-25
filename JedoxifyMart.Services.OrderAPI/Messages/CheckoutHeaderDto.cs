using JedoxifyMart.MessageBus;
using JedoxifyMart.Services.OrderAPI.DTOs;

namespace JedoxifyMart.Services.OrderAPI.Messages
{
    public class CheckoutHeaderDto : BaseMessage
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
