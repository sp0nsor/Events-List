using Events.Application.Authentication;
using Events.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Events.Infrastructure.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }

        public string Generate(User user)
        {
            Claim[] claims =
            [
                new (CustomClaims.UserId, user.Id.ToString())
            ];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(options.ExpiresHours),
                signingCredentials: signingCredentials);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }

    }
}
