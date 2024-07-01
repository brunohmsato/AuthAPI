using AuthAPI.Application.DTOs;
using static AuthAPI.Domain.Responses.CustomResponses;

namespace AuthAPI.Infra.Interfaces;

public interface IAccountRepository
{
    Task<RegistrationResponse> RegisterAsync(RegisterDTO model);

    Task<LoginResponse> LoginAsync(LoginDTO model);
}