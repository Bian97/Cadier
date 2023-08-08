using Cadier.Model.ModelsConfigs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cadier.API.Controllers
{
    [ApiController]
    [Route("autenticacao")]
    public class AutenticacaoController : Controller
    {
        private readonly JwtSettings _jwtSettings;
        public AutenticacaoController(JwtSettings jwtSettings) 
        {
            _jwtSettings = jwtSettings;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] CredenciaisUsuario credenciais)
        {
            // Aqui, você deve verificar as credenciais do usuário (por exemplo, consultar um banco de dados) e decidir se elas são válidas.

            // Se as credenciais forem válidas, gere um token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, credenciais.Cpf),
                //new Claim(ClaimTypes.Name, credenciais.Cpf), NomeUsuario
                    // ... outras reivindicações do usuário, se necessário
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
}