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
    public class SituacaoCadastralController : Controller
    {
        private readonly ILogger<SituacaoCadastralController> _logger;
        private readonly ISituacaoCadastralService _situacaoCadastralService;

        public SituacaoCadastralController(ILogger<SituacaoCadastralController> logger, ISituacaoCadastralService situacaoCadastralService)
        {
            _logger = logger;
            _situacaoCadastralService = situacaoCadastralService;
        }

        [HttpGet("Pegar/{id}", Name = "SituacaoCadastral/Pegar")]
        public async Task<ActionResult> Get(int id)
        {
            var situacaoCadastral = await _situacaoCadastralService.PegarSituacaoCadastralPorIdAsync(id);
            if (situacaoCadastral == null) return NotFound();
            return Ok(situacaoCadastral);
        }

        [HttpPost(Name = "SalvarSituacaoCadastral")]
        public async Task<ActionResult> Create([FromBody] SituacaoCadastral situacaoCadastral)
        {
            if (situacaoCadastral == null) return BadRequest();
            return Ok(await _situacaoCadastralService.SalvarSituacaoCadastralAsync(situacaoCadastral));
        }
    }
}
