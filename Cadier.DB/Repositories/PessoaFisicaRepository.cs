using System;
using System.Collections.Generic;
using System.Linq;
using Cadier.Abstractions.Interfaces.Repositories;
using System.Threading.Tasks;
using Cadier.Model.Models;
using Cadier.DB.Sessions;
using Cadier.DB.Scripts.PFisica;
using Cadier.Model.Enums;
using Dapper;

namespace Cadier.DB.Repositories
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly DbSession _dbSession;

        public PessoaFisicaRepository(DbSession dbSession) 
        {
            _dbSession = dbSession;
        }

        public Task<PFisica> AlterarPessoaFisicaAsync(PFisica pfisica)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GuardarPessoaFisicaAsync(PFisica pfisica)
        {
            return await _dbSession.ExecuteTransactionAsync(
                PessoaFisicaConstants.GuardarPessoaFisica, 
                new DynamicParameters(pfisica)
            );
        }

        public async Task<PFisica> PegarPessoaFisicaPorIdAsync(int id)
        {
            return await _dbSession.QueryFirstOrDefaultAsync<PFisica>(PessoaFisicaConstants.PegarPessoaFisicaPorId, new DynamicParameters(new { Id = id }));
        }

        public async Task<IEnumerable<PFisica>> PegarPessoasFisicasAsync(CondicaoEnum condicaoEnum)
        {
            return await _dbSession.QueryAsync<PFisica>(PessoaFisicaConstants.PegarPessoasFisicas, new DynamicParameters(new { Condicao = (int)condicaoEnum }));
        }        
    }
}