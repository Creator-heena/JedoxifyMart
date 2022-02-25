using AutoMapper;
using JedoxifyMart.Services.StateAPI.DTOs;
using JedoxifyMart.Services.StateAPI.Models;

namespace JedoxifyMart.Services.StateAPI.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<StateDto, State>().ReverseMap();
            });
            return mappingConfig;
        }


    }
}
