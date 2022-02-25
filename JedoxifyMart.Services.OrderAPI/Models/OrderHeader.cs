namespace JedoxifyMart.Services.OrderAPI.Models
{
    public class OrderHeader
    {
        public int OrderHeaderId { get; set; }
        public string UserId { get; set; }
  
        public double OrderTotal { get; set; }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public DateTime OrderTime { get; set; }
         
        public int CartTotalItems { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
