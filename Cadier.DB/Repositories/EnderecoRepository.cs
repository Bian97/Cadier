using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.DB.Scripts.Endereco;
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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DbSession _dbSession;

        public EnderecoRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public Task AlterarEnderecoAsync(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task ApagarEnderecoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> PegarEnderecoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> SalvarEnderecoAsync(Endereco endereco)
        {
            return await _dbSession.ExecuteTransactionAsync(EnderecoConstants.GuardarEndereco,
                new DynamicParameters(endereco)
            );
        }
    }
}
