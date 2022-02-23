using AutoMapper;
using JedoxifyMart.Services.StandsAPI.DTOs;
using JedoxifyMart.Services.StandsAPI.Models;

namespace JedoxifyMart.Services.StandsAPI.Mapper
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<StandDto, Stand>().ReverseMap();
                config.CreateMap<StandDetailsDto, StandDetails>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
