using System.ComponentModel.DataAnnotations;

namespace JedoxifyMart.Services.OrderAPI.DTOs
{
    public class CartHeaderDto
    {
       
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
    }
}
