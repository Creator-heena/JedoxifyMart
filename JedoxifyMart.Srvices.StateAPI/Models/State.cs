using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JedoxifyMart.Services.StateAPI.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        public string DayOfWeek { get; set; }    
       
        [Column(TypeName = "time")]
        public TimeSpan StateStartTime  { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan StateEndTime { get; set; }


    }
}
