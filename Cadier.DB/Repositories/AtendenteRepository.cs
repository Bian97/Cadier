using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.DB.Scripts.Atendente;
using Cadier.DB.Sessions;
using Cadier.Model;
using Cadier.Model.Enums;
using Cadier.Model.Models;
using Dapper;

namespace Cadier.DB.Repositories
{
    public class AtendenteRepository : IAtendenteRepository
    {
        private readonly DbSession _dbSession;

        public AtendenteRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<Atendente> PegarAtendentePorIdAsync(int id)
        {
            return await _dbSession.QueryFirstOrDefaultAsync<Atendente>(AtendenteConstants.PegarAtendentePorId, new DynamicParameters(new { Id = id }));
        }
    }
}
