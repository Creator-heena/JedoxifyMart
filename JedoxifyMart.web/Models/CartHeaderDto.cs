namespace JedoxifyMart.web.Models
{
    public class CartHeaderDto
    {
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }

        public double OrderTotal { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
