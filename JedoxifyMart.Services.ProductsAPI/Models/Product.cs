using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JedoxifyMart.Services.ProductsAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        public Double Price { get; set; }

        public int StandId { get; set; }

    }
}
