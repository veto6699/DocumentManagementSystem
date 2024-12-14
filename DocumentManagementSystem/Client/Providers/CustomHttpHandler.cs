using Microsoft.AspNetCore.Components.Authorization;

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
            if (request.RequestUri.AbsolutePath.ToLower().Contains("login") ||
                request.RequestUri.AbsolutePath.ToLower().Contains("registration"))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var token = await _authStateProvider.GetJWTAccessToken();
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("Authorization", $"Bearer {token}");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
