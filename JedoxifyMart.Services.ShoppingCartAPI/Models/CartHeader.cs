﻿using System.ComponentModel.DataAnnotations;

namespace JedoxifyMart.Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
    }
}
