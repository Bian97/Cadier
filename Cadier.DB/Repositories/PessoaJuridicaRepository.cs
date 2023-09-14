using Cadier.Abstractions.Interfaces.Services;
using Cadier.DB.Scripts.PessoaJuridica;
using Cadier.DB.Sessions;
using Cadier.Model.Enums;
using Cadier.Model.Models;
using Dapper;

namespace Cadier.DB.Repositories
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        private readonly DbSession _dbSession;

        public PessoaJuridicaRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public Task<PJuridica> AlterarPessoaJuridicaAsync(PJuridica pessoaJuridica)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GuardarPessoaJuridicaAsync(PJuridica pessoaJuridica)
        {
            return await _dbSession.ExecuteTransactionAsync(PessoaJuridicaConstants.GuardarPessoaJuridica, 
                new DynamicParameters(new
                {
                    pessoaJuridica.IdPJuridica,//PARA ATUALIZAR A BASE
                    pessoaJuridica.Nome,
                    pessoaJuridica.DataFundacao,
                    pessoaJuridica.Email,
                    IdEndereco = pessoaJuridica.Endereco?.Id,
                    IdSituacaoCadastral = pessoaJuridica.SituacaoCadastral?.Id,
                    pessoaJuridica.Cnpj
                })
            );
        }

        public Task<PJuridica> PegarPessoaJuridicaPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PJuridica>> PegarPessoasJuridicasAsync(CondicaoEnum condicaoEnum)
        {
            return await _dbSession.QueryAsync<PJuridica>(PessoaJuridicaConstants.PegarPessoasJuridicas);
        }
    }
}
