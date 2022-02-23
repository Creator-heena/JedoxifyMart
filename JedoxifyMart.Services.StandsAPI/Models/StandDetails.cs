using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JedoxifyMart.Services.StandsAPI.Models
{
    public class StandDetails
    {
        [Key]
        public int StandDetailId { get; set; }

      
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]

        public virtual Product Product { get; set; }

        
    }
}
