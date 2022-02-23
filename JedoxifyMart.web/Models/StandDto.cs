namespace JedoxifyMart.web.Models
{
    public class StandDto
    {
        public int StandId { get; set; }

        public string StandName { get; set; } = string.Empty;
        public IEnumerable<StandDetailsDto> StandDetails { get; set; }
    }
}
