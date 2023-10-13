using EFGameAPI.DB.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EFGameAPI.Tools
{
    public class TokenManager
    {
        public static string _secretKey = "iuhwerfuewhf087yt89238r230ur2hp23[2-28t34tu8534-ty390]";

        public string GenerateToken(User user)
        {
            // Generate signed key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Data for token and User
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId == 1 ? "User" : "Admin")
            };

            // Build token with all infos
            JwtSecurityToken token = new JwtSecurityToken(
                claims : claims,
                signingCredentials : credentials,
                expires : DateTime.Now.AddDays(1),
                issuer: "monserverapi.com",
                audience: "monsite.com");

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
