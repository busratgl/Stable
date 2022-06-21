using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Helpers
{
    public static class TokenHelper
    {
        public static string GenerateAccessToken(long userId)
        {
            var key = Encoding.ASCII.GetBytes("ajagfiajkfhgafuajkfgafafkajfgk");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", userId.ToString())
                }),

                Expires = System.DateTime.Now.AddMinutes(30),
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
