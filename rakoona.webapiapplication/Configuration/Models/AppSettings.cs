namespace rakoona.webapi.Configuration.Models
{
    public class AppSettings
    {
        private string secret;

        public string Secret { get => secret; set => secret = value; }
    }
}
