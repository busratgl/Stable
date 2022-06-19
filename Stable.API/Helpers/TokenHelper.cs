using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Stable.API.Helpers
{
    public static class TokenHelper
    {
        public static string GenerateAccessToken()
        {
            var key = Encoding.ASCII.GetBytes("ajagfiajkfhgafuajkfgafafkajfgk");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", "1")
                }),

                Expires = System.DateTime.Now.AddDays(7),
                Issuer = "BankingSystem",
                Audience = "BankingSystemServices",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
