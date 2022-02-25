

namespace JedoxifyMart.Services.StateAPI.DTOs
{
    public class StateDto
    {

        public int StateId { get; set; }
     
        public string DayOfWeek{ get; set; }
      

        public TimeSpan StateStartTime { get; set; }
        public TimeSpan StateEndTime { get; set; }
    }
}
