using AuthAPI.Application.DTOs;
using AuthAPI.Application.Interfaces;
using System.Net.Http.Json;
using static AuthAPI.Domain.Responses.CustomResponses;

namespace AuthAPI.Application.Services;

public class AccountService(HttpClient http) : IAccountService
{
    private readonly HttpClient _http = http;

    public async Task<LoginResponse> LoginAsync(LoginDTO model)
    {
        var response = await _http.PostAsJsonAsync("api/account/login", model);
        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
        return result!;
    }

    public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
    {
        var response = await _http.PostAsJsonAsync("api/account/register", model);
        var result = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
        return result!;
    }
}