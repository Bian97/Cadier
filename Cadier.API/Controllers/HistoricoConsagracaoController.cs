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
    public class HistoricoConsagracaoController : Controller
    {
        private readonly IHistoricoConsagracaoService _historicoConsagracaoService;
        private readonly ILogger<HistoricoConsagracaoController> _logger;

        public HistoricoConsagracaoController(IHistoricoConsagracaoService historicoConsagracaoService, ILogger<HistoricoConsagracaoController> logger)
        {
            _logger = logger;
            _historicoConsagracaoService = historicoConsagracaoService;
        }

        [HttpPost(Name = "SalvarHistoricoConsagracao")]
        public async Task<ActionResult> Create([FromBody] HistoricoConsagracao historicoConsagracao)
        {
            if (historicoConsagracao == null) return BadRequest();
            return Ok(await _historicoConsagracaoService.GuardarHistoricoConsagracaoAsync(historicoConsagracao));
        }
    }
}
