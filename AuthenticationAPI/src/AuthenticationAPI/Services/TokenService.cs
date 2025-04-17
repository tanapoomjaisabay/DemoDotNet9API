using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIHelperLIB.Services;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration config;

        public TokenService(IConfiguration config) 
        {
            this.config = config;
        }

        public string BuildToken(BuildTokenModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(model.secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.PrimarySid, model.customerNumber),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: model.issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(model.expireMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public BuildTokenModel GetTokenProperty(UserIdentityModel custInfo, string deviceInfo) 
        {
            return new BuildTokenModel 
            {
                customerNumber = custInfo.customerNumber,
                deviceInfo = deviceInfo,
                secretKey = config["JWT:SecretKey"].ToText(),
                issuer = config["JWT:Issuer"].ToText(),
                expireMinutes = Convert.ToInt32(config["JWT:ExpireMinutes"])
            };
        }
    }
}
