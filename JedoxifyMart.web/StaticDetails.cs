namespace JedoxifyMart.web
{
    public static class StaticDetails
    {
        public static string? ProductsAPIBase { get; set; }

        public static string? ShoppingCartAPIBase { get; set; }

        public static string? StandAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
