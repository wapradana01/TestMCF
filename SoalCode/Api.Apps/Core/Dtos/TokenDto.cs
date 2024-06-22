namespace Core.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiredAt { get; set; }
    }
}
