using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.DB.Scripts.HistoricoConsagracao;
using Cadier.DB.Sessions;
using Cadier.Model.Models;
using Dapper;

namespace Cadier.DB.Repositories
{
    public class HistoricoConsagracaoRepository : IHistoricoConsagracaoRepository
    {
        private readonly DbSession _dbSession;

        public HistoricoConsagracaoRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<int?> GuardarHistoricoConsagracaoAsync(HistoricoConsagracao historicoConsagracao)
        {
            return await _dbSession.ExecuteTransactionAsync
                (
                    HistoricoConsagracaoConstants.GuardarHistoricoConsagracao,
                    new DynamicParameters(new
                    {
                        historicoConsagracao.Cargo,
                        DataLiturgia = historicoConsagracao.Data,
                        historicoConsagracao.Igreja,
                        Lugar = historicoConsagracao.Local,
                        historicoConsagracao.NomeIndicou,
                        historicoConsagracao.Obs,
                        IdPfi = historicoConsagracao.PFisica.IdPFisica
                    })
                );
        }
    }
}
