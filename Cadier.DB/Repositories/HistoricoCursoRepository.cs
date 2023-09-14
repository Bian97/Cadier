using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.DB.Scripts.HistoricoCurso;
using Cadier.DB.Sessions;
using Cadier.Model.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadier.DB.Repositories
{
    public class HistoricoCursoRepository : IHistoricoCursoRepository
    {
        private readonly DbSession _dbSession;

        public HistoricoCursoRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<IEnumerable<HistoricoCursos>> PegarHistoricoCursoPorPessoaFisicaAsync(int pessoaFisicaId)
        {
            return await _dbSession.QueryAsync<HistoricoCursos>
                (
                    HistoricoCursoConstants.PegarHistoricoCursoPorPessoaFisica,
                    new DynamicParameters(new { PessoaFisicaId = pessoaFisicaId })
                );
        }

        public async Task<int?> GuardarHistoricoCursoAsync(HistoricoCursos historicoCurso)
        {
            return await _dbSession.ExecuteTransactionAsync
                (
                    HistoricoCursoConstants.GuardarHistoricoCurso,
                    new DynamicParameters(new
                    {
                        historicoCurso.Curso,
                        historicoCurso.DataFormatura,
                        DataLevouCertificado = historicoCurso.DataLevouCert,
                        DataUltimoPagamento = historicoCurso.DataUltimPagam,
                        historicoCurso.Periodo,
                        historicoCurso.Obs,
                        historicoCurso.RestaPagar,
                        IdPfi = historicoCurso.PFisica.IdPFisica
                    })
                );
        }
    }
}
