using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CadastroDeCompras.Domain.Authentication;
using CadastroDeCompras.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CadastroDeCompras.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGeneretor
    {
        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projetoDeCadastroDeComprasAPIDotnet6"));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {
                acess_token = token,
                expirations = expires
            };
        }
    }
}