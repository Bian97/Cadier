using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model;
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
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly IAtendenteService _atendenteService;

        public AutenticacaoController(JwtSettings jwtSettings, IPessoaFisicaService pessoaFisicaService, IAtendenteService atendenteService)
        {
            _jwtSettings = jwtSettings;
            _pessoaFisicaService = pessoaFisicaService;
            _atendenteService = atendenteService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CredenciaisUsuario credenciais)
        {
            try
            {
                if (string.IsNullOrEmpty(credenciais.Documento) || !credenciais.Numero.HasValue)
                    return BadRequest();

                var loginSucesso = false;
                if (credenciais.Atendente)
                    loginSucesso = (await _atendenteService.LoginAtendenteAsync(credenciais.Documento, credenciais.Numero.Value));
                else
                    loginSucesso = (await _pessoaFisicaService.LoginPessoaFisicaAsync(credenciais.Documento, credenciais.Numero.Value));

                if (!loginSucesso)
                    return Unauthorized();

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, credenciais.Documento),
                    new Claim(ClaimTypes.Sid, credenciais.Numero.Value.ToString()),
                    new Claim(ClaimTypes.Role, credenciais.Atendente ? "Admin" : "User"),
                    }),
                    Expires = DateTime.UtcNow.AddHours(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Audience = _jwtSettings.Audience,
                    Issuer = _jwtSettings.Issuer
                };
                var tokenString = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

                return Ok(new { Token = tokenString, Documento = credenciais.Documento, Numero = credenciais.Numero, Atendente = credenciais.Atendente, PossuiConta = true });
            }
            catch(TimeoutException)
            {
                return BadRequest();
            }
        }
    }
}