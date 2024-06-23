using System.Text.Json.Serialization;

namespace Webui.Apps.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponse
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; } = string.Empty;
        [JsonPropertyName("expiredAt")]
        public DateTime ExpiredAt { get; set; }
    }
}
