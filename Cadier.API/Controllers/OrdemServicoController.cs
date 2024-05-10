using Cadier.Abstractions.Interfaces.Services;
using Cadier.Business;
using Cadier.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cadier.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrdemServicoController : Controller
    {
        private readonly IOrdemServicoService _ordemServicoService;
        private readonly ILogger<OrdemServicoController> _logger;

        public OrdemServicoController(IOrdemServicoService ordemServicoService, ILogger<OrdemServicoController> logger)
        {
            _ordemServicoService = ordemServicoService;
            _logger = logger;
        }

        [HttpPost(Name = "GuardarOrdemServico")]
        public async Task<ActionResult> Create([FromBody] OrdemServico ordemServico)
        {
            if (ordemServico == null) return BadRequest();
            return Ok(await _ordemServicoService.GuardarOrdemServicoAsync(ordemServico));
        }
    }
}
