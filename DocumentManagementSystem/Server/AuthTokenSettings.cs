using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DocumentManagementSystem.Server
{
    public class AuthTokenSettings
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        public string? Issuer { get; set; }
        /// <summary>
        /// Получатель токена
        /// </summary>
        public string? Audience { get; set; }
        /// <summary>
        /// Ключ шифрования токена
        /// </summary>
        public string? SecretKey { get; set;}
    }
}
