using AuthAPI.Application.DTOs;
using static AuthAPI.Domain.Responses.CustomResponses;

namespace AuthAPI.Application.Interfaces;

public interface IAccountService
{
    Task<RegistrationResponse> RegisterAsync(RegisterDTO model);

    Task<LoginResponse> LoginAsync(LoginDTO model);
}