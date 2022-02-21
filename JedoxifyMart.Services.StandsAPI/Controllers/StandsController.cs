using AutoMapper;
using JedoxifyMart.Services.StandsAPI.DTOs;
using JedoxifyMart.Services.StandsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace JedoxifyMart.Services.StandsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandsController : ControllerBase
    {
        private readonly IStandRepo _repositery;
        private readonly IMapper _mapper;
        //  private readonly ICustomerDataClient _customerDataClient;

        public StandsController(
            IStandRepo repositery, IMapper mapper)
       //     ICustomerDataClient customerDataClient)
        {
            _repositery = repositery;
            _mapper = mapper;
       //     _customerDataClient = customerDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StandReadDto>> GetStands()
        {
           
            var standItem = _repositery.GetAllStands();
            return Ok(_mapper.Map<IEnumerable<StandReadDto>>(standItem));
        }

        [HttpGet("{id}", Name="GetStandById")]
        public ActionResult<IEnumerable<StandReadDto>> GetStandById(int id)
        {
            var standItem = _repositery.GetStandById(id);
            if(standItem != null)
            {

                return Ok(_mapper.Map<StandReadDto>(standItem));
            }
            return NotFound();
        }
        [HttpPost()]
        public ActionResult<StandReadDto> CreateStand(StandCreateDto standCreateDto)
        {
            var standModel = _mapper.Map<Stand>(standCreateDto);
            _repositery.CreateStand(standModel);
            _repositery.SaveChanges();
            var standReadDto = _mapper.Map<StandReadDto>(standModel);
    
            return CreatedAtRoute(nameof(GetStandById), new {Id = standReadDto.StandId},standReadDto.StandId);

        }
    }
}  