using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Cadier.Model.Models;
using Cadier.Model.Enums;
using Cadier.Abstractions.Interfaces.Services;

namespace Cadier.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PessoaFisicaController : Controller
    {
        private readonly ILogger<PessoaFisicaController> _logger;
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public PessoaFisicaController(ILogger<PessoaFisicaController> logger, IPessoaFisicaService pfisicaService)
        {
            _logger = logger;
            _pessoaFisicaService = pfisicaService;
        }

        [HttpGet("GetPFisicas/{Condicao}", Name = "GetPFisicas")]
        public async Task<ActionResult> Index(CondicaoEnum condicaoEnum)
        {
            var pfisicas = await _pessoaFisicaService.PegarPessoasFisicas(condicaoEnum);
            if(pfisicas == null) return NotFound();
            return Ok(pfisicas);
        }

        [HttpGet("Detalhes/{id}", Name = "GetPFisica/Detalhes")]
        public async Task<ActionResult> Details(int id)
        {         
            return Ok();
        }      

        [HttpPost(Name = "CadastrarPessoaFisica")]
        public async Task<ActionResult> Create([FromBody] PFisica pessoaFisica)
        {
            if (pessoaFisica == null) return BadRequest();
            return Ok(await _pessoaFisicaService.GuardarPessoaFisica(pessoaFisica));
        }

        [HttpPut(Name = "AlterarPessoaFisica")]       
        public ActionResult Edit([FromBody] PFisica pfisica)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}