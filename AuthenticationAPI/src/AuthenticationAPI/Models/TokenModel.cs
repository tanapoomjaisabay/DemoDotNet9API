namespace AuthenticationAPI.Models
{
    public class BuildTokenModel
    {
        public string customerNumber { get; set; } = string.Empty;
        public string deviceInfo { get; set; } = string.Empty;
        public string secretKey { get; set; } = string.Empty;
        public string issuer { get; set; } = string.Empty;
        public int expireMinutes { get; set; }
    }
}
