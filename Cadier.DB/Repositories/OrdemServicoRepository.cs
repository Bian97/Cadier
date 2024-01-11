using Azure;
using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.DB.Scripts.OrdemServico;
using Cadier.DB.Sessions;
using Cadier.Model.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadier.DB.Repositories
{
    public class OrdemServicoRepository : IOrdemServicoRepository
    {
        private readonly DbSession _dbSession;

        public OrdemServicoRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<int?> GuardarOrdemServicoAsync(OrdemServico ordemServico)
        {
            return await _dbSession.ExecuteTransactionAsync
                (
                    OrdemServicoConstants.GuardarOrdemServico,
                    new DynamicParameters(ordemServico)
                );
        }
    }
}
