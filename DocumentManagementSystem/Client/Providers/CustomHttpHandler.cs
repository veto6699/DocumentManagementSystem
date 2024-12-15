using Microsoft.AspNetCore.Components.Authorization;
using System.Net;

namespace DocumentManagementSystem.Client.Providers
{
    public class CustomHttpHandler : DelegatingHandler
    {
        private readonly AuthStateProvider _authStateProvider;

        public CustomHttpHandler(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = (AuthStateProvider)authStateProvider;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var pathToLower = request.RequestUri.AbsolutePath.ToLower();

            if (pathToLower.Contains("refreshaccesstoken") ||
                pathToLower.Contains("login") ||
                pathToLower.Contains("registration"))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var token = await _authStateProvider.GetJWTAccessToken();

            if (!string.IsNullOrEmpty(token))
                request.Headers.Add("Authorization", $"Bearer {token}");

            var response = await base.SendAsync(request, cancellationToken);

            if (response is not null && response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _authStateProvider.ResetAuthState();
                request.Headers.Remove("Authorization");

                token = await _authStateProvider.GetJWTAccessToken();

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Add("Authorization", $"Bearer {token}");

                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            return response;
        }
    }
}
