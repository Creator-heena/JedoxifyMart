using System.ComponentModel.DataAnnotations.Schema;

namespace JedoxifyMart.Services.StandsAPI.DTOs
{
    public class StandDetailsDto
    {


        public int StandDetailId { get; set; }


            public int ProductId { get; set; }

        public virtual ProductDto Product { get; set; }
    }
}
