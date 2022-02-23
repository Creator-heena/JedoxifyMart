using AutoMapper;
using JedoxifyMart.Services.StandsAPI.DTOs;
using JedoxifyMart.Services.StandsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace JedoxifyMart.Services.StandsAPI.Controllers
{
    [Route("api/stands")]
    [ApiController]
    public class StandController : ControllerBase
    {
        private readonly IStandRepo _repositery;
   
        protected ResponseDto _response;
      
         
            

        public StandController(
            IStandRepo repositery)
  
        {
            _repositery = repositery;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> GetAllStands()
        {

            IEnumerable<StandDto> standDtos = await _repositery.GetAllStands();
            _response.Result = standDtos;
            return _response;
        }

        //[HttpGet("{id}", Name="GetStandById")]
        //public ActionResult<IEnumerable<StandReadDto>> GetStandById(int id)
        //{
        //    var standItem = _repositery.GetStandById(id);
        //    if(standItem != null)
        //    {

        //        return Ok(_mapper.Map<StandReadDto>(standItem));
        //    }
        //    return NotFound();
        //}
        //[HttpPost()]
        //public ActionResult<StandReadDto> CreateStand(StandCreateDto standCreateDto)
        //{
        //    var standModel = _mapper.Map<Stand>(standCreateDto);
        //    _repositery.CreateStand(standModel);
        //    _repositery.SaveChanges();
        //    var standReadDto = _mapper.Map<StandReadDto>(standModel);

        //    return CreatedAtRoute(nameof(GetStandById), new {Id = standReadDto.StandId},standReadDto.StandId);

        //}
    }
}  