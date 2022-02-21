using AutoMapper;
using JedoxifyMart.Services.ShoppingCartAPI.DTOs;
using JedoxifyMart.Services.ShoppingCartAPI.Models;

namespace JedoxifyMart.Services.ShoppingCartAPI.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailsDto, CartDetails>().ReverseMap();
                config.CreateMap<CartDto, Cart>().ReverseMap();
            });
            return mappingConfig;
        }


    }
}
