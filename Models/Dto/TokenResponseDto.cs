namespace Ban_Caffee.Models.Dto
{
    public class TokenResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
    }
}
