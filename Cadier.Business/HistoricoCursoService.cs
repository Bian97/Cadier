using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadier.Business
{
    public class HistoricoCursoService : IHistoricoCursoService
    {
        private readonly IHistoricoCursoRepository _historicoCursoRepository;

        public HistoricoCursoService(IHistoricoCursoRepository historicoCurso) 
        {
            _historicoCursoRepository = historicoCurso;
        }

        public async Task<IEnumerable<HistoricoCursos>> PegarHistoricoCursoPorPessoaFisicaAsync(int pessoaFisicaId)
        {
            return await _historicoCursoRepository.PegarHistoricoCursoPorPessoaFisicaAsync(pessoaFisicaId);
        }

        public async Task<int?> GuardarHistoricoCursoAsync(HistoricoCursos historicoCurso)
        {
            return await _historicoCursoRepository.GuardarHistoricoCursoAsync(historicoCurso);
        }
    }
}
