using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Responses
{
    public class RefreshAccessTokenResponse(string accessToken, string refreshToken)
    {
        /// <summary>
        /// Токен авторизации
        /// </summary>
        public string AccessToken { get; set; } = accessToken;
        /// <summary>
        /// Токен обновления токена авторизации
        /// </summary>
        public string RefreshToken { get; set; } = refreshToken;
    }
}
