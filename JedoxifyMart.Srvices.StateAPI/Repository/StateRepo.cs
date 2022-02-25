using AutoMapper;
using JedoxifyMart.Services.StateAPI.Data;
using JedoxifyMart.Services.StateAPI.DTOs;
using JedoxifyMart.Services.StateAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.StateAPI.Repository
{
    public class StateRepo : IStateRepo
    {
        private readonly AppDBContext _context;
        private IMapper _mapper;
        public StateRepo(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StateDto> GetStateByTime()
        {

            var currentTime = DateTime.Now.TimeOfDay;
            var currentDay = DateTime.Now.DayOfWeek.ToString();

            State state = await _context.states.Where(p =>
            p.DayOfWeek == currentDay).FirstOrDefaultAsync();
            return _mapper.Map<StateDto>(state);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<StateDto> UpdateState(StateDto state)
        {
            throw new NotImplementedException();
        }

       public async Task<string> GetCurrentState()
        {
            var currentTime = DateTime.Now.TimeOfDay;
            var currentDay = DateTime.Now.DayOfWeek.ToString();
            string CurrentStateOfMall;

            State state = await _context.states.Where(p =>
            p.DayOfWeek == currentDay).FirstOrDefaultAsync();
            if (state != null)
            { 
                CurrentStateOfMall = (currentTime.CompareTo(state.StateStartTime) < 0 && currentTime.CompareTo(state.StateEndTime) > 0)? "JedoxifyMart is Opened" : "JedoxifyMart is Opened";
                return CurrentStateOfMall;
            }
            else
            {
                throw new NullReferenceException();
            }
           

        }
    }
}
