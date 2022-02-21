using System.ComponentModel.DataAnnotations; 

namespace JedoxifyMart.Services.StandsAPI.Models
{
    public class Stand
    {

        [Key]
        [Required]
        public int StandId { get; set; }

        [Required]
        public string StandName { get; set; } = string.Empty;

     
    }
}
