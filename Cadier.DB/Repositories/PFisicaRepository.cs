using System;
using System.Collections.Generic;
using System.Linq;
using Cadier.Abstractions.Interfaces.Repositories;
using System.Threading.Tasks;
using Cadier.Model.Models;
using Cadier.DB.Sessions;
using Cadier.DB.Scripts.PFisica;
using Cadier.Model.Enums;

namespace Cadier.DB.Repositories
{
    public class PFisicaRepository : IPFisicaRepository
    {
        private readonly DbSession _dbSession;

        public PFisicaRepository(DbSession dbSession) 
        {
            _dbSession = dbSession;
        }

        public Task<PFisica> AlterarPFisicaAsync(PFisica pfisica)
        {
            throw new NotImplementedException();
        }

        public Task<int> GuardarPFisicaAsync(PFisica pfisica)
        {
            throw new NotImplementedException();
        }

        public Task<PFisica> PegarPFisicaPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PFisica>> PegarPFisicasAsync(CondicaoEnum condicaoEnum)
        {
            return await _dbSession.QueryAsync<PFisica>(PFisicaConstants.PegarPFisicas, new Dapper.DynamicParameters(new { Condicao = (int)condicaoEnum }));
        }        
    }
}