using AuthAPI.Application.DTOs;
using AuthAPI.Domain.Entities;
using AuthAPI.Infra.Data.Data;
using AuthAPI.Infra.Interfaces;
using AuthAPI.JWT;
using Microsoft.EntityFrameworkCore;
using static AuthAPI.Domain.Responses.CustomResponses;

namespace AuthAPI.Infra.Repositories
{
    public class AccountRepository(AppDbContext context, TokenGeneration token) : IAccountRepository
    {
        private readonly AppDbContext _context = context;
        private readonly TokenGeneration _token = token;

        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var findUser = await GetUser(model.Email);

            if (findUser is null)
                return new LoginResponse(false, "Usuário não encontrado.");

            if (!BCrypt.Net.BCrypt.Verify(model.Password, findUser.Password))
                return new LoginResponse(false, "Email/Senha não válido");

            string jwtToken = _token.GenerateToken(findUser);
            return new LoginResponse(true, "Logado com sucesso!", jwtToken);
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var findUser = await GetUser(model.Email);

            if (findUser != null)
                return new RegistrationResponse(false, "Usuário existente.");

            _context.Users.Add(
                new ApplicationUser()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
                });

            await _context.SaveChangesAsync();
            return new RegistrationResponse(true, "Cadastrado com sucesso!");
        }

        private async Task<ApplicationUser> GetUser(string email)
            => await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
    }
}