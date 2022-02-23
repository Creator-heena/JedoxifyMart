using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JedoxifyMart.Services.StandsAPI.DTOs
{
    public class ProductDto
    {
        
        public int ProductId { get; set; }
       
        public string ProductName { get; set; } = string.Empty;

        public double Price { get; set; }

    }
}
