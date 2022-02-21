using System.ComponentModel.DataAnnotations.Schema;

namespace JedoxifyMart.Services.ShoppingCartAPI.DTOs
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }

        public string CartHeaderId { get; set;}
    

        public virtual CartHeaderDto CartHeader { get; set;}

        public int ProductId { get; set; }
    
        public virtual ProductDto Product { get; set; }

        public int ProductCount { get; set; }
    }
}
