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
    public class PFisicaController : Controller
    {
        private readonly ILogger<PFisicaController> _logger;
        private readonly IPFisicaService _pfisicaService;

        public PFisicaController(ILogger<PFisicaController> logger, IPFisicaService pfisicaService)
        {
            _logger = logger;
            _pfisicaService = pfisicaService;

        }

        [HttpGet("GetPFisicas/{Condicao}", Name = "GetPFisicas")]
        public async Task<ActionResult> Index(CondicaoEnum condicaoEnum)
        {
            var pfisicas = await _pfisicaService.PegarPFisicas(condicaoEnum);
            if(pfisicas == null) return NotFound();
            return Ok(pfisicas);
        }

        [HttpGet("Detalhes/{id}", Name = "GetPFisica/Detalhes")]
        public async Task<ActionResult> Details(int id)
        {         
            return Ok();
        }      

        [HttpPost(Name = "Cadastrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] PFisica pfisica)
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

        [HttpPut(Name = "Alterar")]
        [ValidateAntiForgeryToken]
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