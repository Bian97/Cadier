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
using Cadier.Model;

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

        public async Task<IEnumerable<PFisica>> PegarPessoasFisicasComFiltrosAsync(PFisica pfisica)
        {
            return await _dbSession.QueryAsync<PFisica, Endereco, SituacaoCadastral, PJuridica, Atendente>(PessoaFisicaConstants.PegarPessoasFisicas,
                (pFisica, endereco, situacaoCadastral, idPJuridica, atendente) =>
                {
                    // Aqui você pode realizar o mapeamento personalizado, se necessário
                    pFisica.Endereco = endereco;
                    pFisica.SituacaoCadastral = situacaoCadastral;
                    pFisica.PessoaJuridica = idPJuridica;
                    pFisica.Atendente = atendente;
                    return pFisica;
                }
                , new string[] { "IdPFisica", "IdEndereco", "IdSituacaoCadastral", "IdPJuridica", "IdAtendente" },
                new DynamicParameters(new 
                { 
                    pfisica.IdPFisica,
                    pfisica.DocumentoIdentificacaoSocial,
                    pfisica.PessoaJuridica.IdPJuridica,
                    NomePessoaJuridica = pfisica.PessoaJuridica.Nome,
                    pfisica.Endereco.Cidade,
                    pfisica.Endereco.Estado,
                    pfisica.Endereco.Pais,
                    pfisica.SituacaoCadastral.Condicao,
                    Filiado = pfisica.SituacaoCadastral.EFiliado
                }));
        }        
    }
}