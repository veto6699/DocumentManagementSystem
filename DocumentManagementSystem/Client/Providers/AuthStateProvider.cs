using Blazored.LocalStorage;
using DocumentManagementSystem.Client.Constants;
using DocumentManagementSystem.Shared.Requests;
using DocumentManagementSystem.Shared.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

public class AuthStateProvider(ILocalStorageService localStorageService, NavigationManager nav) : AuthenticationStateProvider
{
    readonly ClaimsPrincipal _anonym = new(new ClaimsIdentity());
    readonly ILocalStorageService _localStorageService = localStorageService;
    readonly string _baseAddress = nav.BaseUri;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var jwtToken = await _localStorageService.GetItemAsync<string>(Names.JWTAccessToken);

        if (string.IsNullOrEmpty(jwtToken))
            return new AuthenticationState(_anonym);

        var claims = ParseClaimsFromJwt(jwtToken);

        if(claims is null)
            return new AuthenticationState(_anonym);

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtAuth"));

        var expirationClaim = claimsPrincipal.FindFirst("exp");

        if (expirationClaim is null)
            return new AuthenticationState(_anonym);

        if(!long.TryParse(expirationClaim.Value, out long unixTime))
            return new AuthenticationState(_anonym);

        var date = DateTimeOffset.FromUnixTimeSeconds(unixTime);

        if (date <= DateTime.UtcNow)
        {
            var refreshToken = await _localStorageService.GetItemAsync<string>(Names.RefreshToken);

            if(refreshToken is null)
                return new AuthenticationState(_anonym);

            var login = JsonContent.Create(new RefreshAccessTokenRequest(refreshToken));

            var response = await new HttpClient().PostAsync(_baseAddress + "Authentication/RefreshAccessToken", login);

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
                return new AuthenticationState(_anonym);

            var tokens = await JsonSerializer.DeserializeAsync<RefreshAccessTokenResponse>(response.Content.ReadAsStream(), SystemConstants.serializerOptions);

            SetTokens(tokens.AccessToken, tokens.RefreshToken);

            return await GetAuthenticationStateAsync();
        }

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtAuth")));
    }

    private static List<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var payloadСorrected = payload.Replace("_", "/").Replace("-", "+");

        var jsonBytes = ParseBase64WithoutPadding(payloadСorrected);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())).ToList();
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }

    internal async void ChangeTokens(string accessToken, string refreshToken)
    {
        await SetTokens(accessToken, refreshToken);
        ChangeAuthState();
    }

    internal async Task<string?> GetJWTAccessToken()
    {
        return await _localStorageService.GetItemAsync<string>(Names.JWTAccessToken);
    }

    private async Task SetTokens(string accessToken, string refreshToken)
    {
        await SetAccessToken(accessToken);
        await SetRefreshToken(refreshToken);
    }

    private async Task SetAccessToken(string token)
    {
        await _localStorageService.SetItemAsync<string>(Names.JWTAccessToken, token);
    }

    private async Task SetRefreshToken(string token)
    {
        await _localStorageService.SetItemAsync<string>(Names.RefreshToken, token);
    }

    internal async void DeleteAuthState()
    {
        await _localStorageService.RemoveItemAsync(Names.JWTAccessToken);
        ChangeAuthState();
    }

    private void ChangeAuthState()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }    
}