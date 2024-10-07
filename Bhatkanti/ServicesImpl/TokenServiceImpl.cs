using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bhatkanti.ServicesImpl
{
    public class TokenServiceImpl : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenServiceImpl(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(Guide guide)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, guide.Guide_ID.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
