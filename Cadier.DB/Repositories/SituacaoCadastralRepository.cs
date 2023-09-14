using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.DB.Scripts.SituacaoCadastral;
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
    public class SituacaoCadastralRepository : ISituacaoCadastralRepository
    {
        private readonly DbSession _dbSession;

        public SituacaoCadastralRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public Task AlterarSituacaoCadastralAsync(SituacaoCadastral situacaoCadastral)
        {
            throw new NotImplementedException();
        }

        public Task ApagarSituacaoCadastralPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SituacaoCadastral> PegarSituacaoCadastralPorIdAsync(int id)
        {
            return await _dbSession.QueryFirstOrDefaultAsync<SituacaoCadastral>(SituacaoCadastralConstants.PegarSituacaoCadastralPorId,
                new DynamicParameters(new { Id = id })
            );
        }

        public async Task<int?> SalvarSituacaoCadastralAsync(SituacaoCadastral situacaoCadastral)
        {
            return await _dbSession.ExecuteTransactionAsync(SituacaoCadastralConstants.GuardarSituacaoCadastral,
                new DynamicParameters(situacaoCadastral)
            );
        }
    }
}
