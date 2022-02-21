using AutoMapper;
using JedoxifyMart.Services.ProductsAPI.DTOs;
using JedoxifyMart.Services.ProductsAPI.Models;

namespace JedoxifyMart.Services.ProductsAPI.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }


    }
}
