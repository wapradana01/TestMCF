namespace DataAccess.SharedObjects
{
    public class SecurityConfig
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        /// <summary>
        /// Value In Minutes
        /// </summary>
        public int TokenExpired { get; set; }
    }
}
