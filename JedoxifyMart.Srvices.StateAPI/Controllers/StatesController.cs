using JedoxifyMart.Services.StateAPI.DTOs;
using JedoxifyMart.Services.StateAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JedoxifyMart.Services.StateAPI.Controllers
{
    [Route("api/states")]
    public class StatesController : ControllerBase
    {

        private IStateRepo _stateRepo;
        protected ResponseDto _response;

        public StatesController(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> GetStateOfToday()
        {
            try
            {
                StateDto stateDto = await _stateRepo.GetStateByTime();
                _response.Result = stateDto;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;

        }
        [HttpGet("GetState")]
        public async Task<object> GetCurentState()
        {
            try
            {
                string state = await _stateRepo.GetCurrentState();
                _response.DisplayMessage = state;
               

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
               
            }
            return _response;

        }

    }
}
