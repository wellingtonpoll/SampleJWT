using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SampleJWT.API.Services
{
    public class AccountService
    {
        public async Task<string> GenerateTokenAsync()
        {
            return await Task.Run(() =>
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("639B8D73-8B80-415A-AB1A-FE5A499872D4");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "wellington luiz do nascimento"),
                        new Claim("id", new Random().Next(int.MinValue, int.MaxValue).ToString()),
                        new Claim("company", "get")
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            });
        }

        public object GetById(int id)
        {
            return new
            {
                UserId = id,
                Name = "wellington luiz do nascimento"
            };
        }
    }
}
