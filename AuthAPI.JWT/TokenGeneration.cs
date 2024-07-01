using AuthAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.JWT
{
    public class TokenGeneration(IConfiguration config)
    {
        private readonly IConfiguration _config = config;

        public string GenerateToken(ApplicationUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]!));
            var credenditals = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var userClaims = new List<Claim>()
            {
                new(ClaimTypes.Name,user.Name!),
                new(ClaimTypes.Email,user.Email!),
            };

            var token = new JwtSecurityToken
                            (
                                issuer: _config["JWT:Issuer"]!,
                                audience: _config["JWT:Audience"]!,
                                claims: userClaims,
                                expires: DateTime.Now.AddMinutes(1),
                                signingCredentials: credenditals
                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}