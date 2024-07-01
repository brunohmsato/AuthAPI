using AuthAPI.Application.DTOs;
using AuthAPI.Infra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AuthAPI.Domain.Responses.CustomResponses;

namespace AuthAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAccountRepository repository) : ControllerBase
    {
        private readonly IAccountRepository _repository = repository;

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterDTO model)
        {
            var result = await _repository.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            var result = await _repository.LoginAsync(model);
            return Ok(result);
        }
    }
}