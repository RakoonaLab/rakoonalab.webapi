namespace rakoona.dtos.Response
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public PlanResponse Plan { get; set; }
    }
}
