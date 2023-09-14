using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cadier.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PessoaJuridicaController : Controller
    {
        private readonly ILogger<PessoaJuridicaController> _logger;
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public PessoaJuridicaController(ILogger<PessoaJuridicaController> logger, IPessoaJuridicaService pessoaJuridicaService)
        {
            _logger = logger;
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        [HttpGet("Pegar/{id}", Name = "PessoaJuridica/Pegar")]
        public async Task<ActionResult> Get(int id)
        {
            var pessoaJuridica = await _pessoaJuridicaService.PegarPessoaJuridicaPorIdAsync(id);
            if (pessoaJuridica == null) return NotFound();
            return Ok(pessoaJuridica);
        }

        [HttpPost(Name = "SalvarPessoaJuridica")]
        public async Task<ActionResult> Create([FromBody] PJuridica pessoaJuridica)
        {
            if (pessoaJuridica == null) return BadRequest();
            return Ok(await _pessoaJuridicaService.GuardarPessoaJuridicaAsync(pessoaJuridica));
        }
    }
}
