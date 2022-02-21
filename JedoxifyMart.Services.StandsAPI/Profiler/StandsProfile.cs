using AutoMapper;
using JedoxifyMart.Services.StandsAPI.DTOs;
using JedoxifyMart.Services.StandsAPI.Models;

namespace JedoxifyMart.Services.StandsAPI.Profiler
{
    public class StandsProfile : Profile
    {
        public StandsProfile()
        {
            // Source -> Target
            CreateMap<Stand, StandReadDto>();
            CreateMap<StandCreateDto, Stand>();
        }
    }
}
