using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JedoxifyMart.Services.StandsAPI.Models
{
    public class Stand
    {

        [Key]
        public int StandId { get; set; }
        [Required]
        public string StandName { get; set; } = string.Empty;

        public IEnumerable<StandDetails> StandDetails { get; set; }

    }
}
