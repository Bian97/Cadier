using Cadier.Abstractions.Interfaces.Services;
using Cadier.Business;
using Cadier.Model.Enums;
using Cadier.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cadier.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EnderecoController : Controller
    {
        private readonly ILogger<EnderecoController> _logger;
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(ILogger<EnderecoController> logger, IEnderecoService enderecoService)
        {
            _logger = logger;
            _enderecoService = enderecoService;
        }        

        [HttpGet("Pegar/{id}", Name = "Endereco/Pegar")]
        public async Task<ActionResult> Get(int id)
        {
            var endereco = await _enderecoService.PegarEnderecoPorIdAsync(id);
            if (endereco == null) return NotFound();
            return Ok(endereco);            
        }

        [HttpPost(Name = "SalvarEndereco")]
        public async Task<ActionResult> Create([FromBody] Endereco endereco)
        {
            if (endereco == null) return BadRequest();
            return Ok(await _enderecoService.SalvarEnderecoAsync(endereco));
        }
    }
}
