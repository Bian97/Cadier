using Cadier.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadier.Abstractions.Interfaces.Repositories
{
    public interface IHistoricoCursoRepository
    {
        Task<int?> GuardarHistoricoCursoAsync(HistoricoCursos historicoCurso);
        Task<IEnumerable<HistoricoCursos>> PegarHistoricoCursoPorPessoaFisicaAsync(int pessoaFisicaId);
    }
}
