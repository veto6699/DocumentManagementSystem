using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Buffers.Text;
using System.Security.Claims;
using System.Text.Json;

internal class AuthStateProvider(ILocalStorageService localStorageService) : AuthenticationStateProvider
{
    readonly ClaimsPrincipal anonym = new(new ClaimsIdentity());
    readonly ILocalStorageService _localStorageService = localStorageService;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var jwtToken = await _localStorageService.GetItemAsync<string>("jwt-access-token");

        if (string.IsNullOrEmpty(jwtToken))
            return new AuthenticationState(anonym);

        var claims = ParseClaimsFromJwt(jwtToken);

        return new AuthenticationState(new ClaimsPrincipal(
            new ClaimsIdentity(claims, "JwtAuth")));
    }

    private static List<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var payloadСorrected = payload.Replace("_","/").Replace("-", "+");

        var jsonBytes = ParseBase64WithoutPadding(payload);
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

    internal async void DeleteAuthState()
    {
        await _localStorageService.RemoveItemAsync("jwt-access-token");
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    internal void ChangeAuthState()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }    
}