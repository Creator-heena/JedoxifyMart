namespace JedoxifyMart.Services.OrderAPI.DTOs
{
    public class ProductDto
    {
        
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public Double Price { get; set; }

        public int StandId { get; set; }

    }
}
