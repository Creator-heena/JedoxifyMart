using System.ComponentModel.DataAnnotations;

namespace JedoxifyMart.web.Models
{
    public class ProductDto
    {
        public ProductDto()
        {
            ProductCount = 1;
        }
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public Double Price { get; set; }

        public int StandId { get; set; }

        [Range (1, 10)]
        public int ProductCount { get; set;}


    }
}
