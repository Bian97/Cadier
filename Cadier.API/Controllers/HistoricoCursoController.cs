using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadier.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HistoricoCursoController : Controller
    {
        private readonly ILogger<HistoricoCursoController> _logger;
        private readonly IHistoricoCursoService _historicoCursoService;

        public HistoricoCursoController(ILogger<HistoricoCursoController> logger, IHistoricoCursoService historicoCursoService)
        {
            _logger = logger;
            _historicoCursoService = historicoCursoService;
        }

        //[HttpGet("Detalhes/{id}", Name = "GetHistoricoCurso/Detalhes")]
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        [HttpPost(Name = "CadastrarHistoricoCurso")]
        public async Task<ActionResult> Create([FromBody] HistoricoCursos historicoCurso)
        {
            if (historicoCurso == null) return BadRequest();
            return Ok(await _historicoCursoService.GuardarHistoricoCursoAsync(historicoCurso));
        }

        //// POST: HistoricoCursoController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: HistoricoCursoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: HistoricoCursoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HistoricoCursoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: HistoricoCursoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
