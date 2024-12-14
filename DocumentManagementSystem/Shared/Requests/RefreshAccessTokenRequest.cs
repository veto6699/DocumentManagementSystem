using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Requests
{
    public class RefreshAccessTokenRequest(string refreshToken)
    {
        /// <summary>
        /// Токен обновления токена авторизации
        /// </summary>
        public string RefreshToken { get; set; } = refreshToken;
    }
}
