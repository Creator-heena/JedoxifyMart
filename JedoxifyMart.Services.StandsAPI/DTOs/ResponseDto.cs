namespace JedoxifyMart.Services.StandsAPI.DTOs
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result  { get; set; }

        public string DisplayMessage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
