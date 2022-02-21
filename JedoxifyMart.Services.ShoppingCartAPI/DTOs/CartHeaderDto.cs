using System.ComponentModel.DataAnnotations;

namespace JedoxifyMart.Services.ShoppingCartAPI.DTOs
{
    public class CartHeaderDto
    {
       
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
    }
}
