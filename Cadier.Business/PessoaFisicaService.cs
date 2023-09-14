using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Enums;
using Cadier.Model.Models;
using System.Text.RegularExpressions;

namespace Cadier.Business
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository) 
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public Task<PFisica> AlterarPessoaFisica(PFisica pfisica)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GuardarPessoaFisica(PFisica pfisica)
        {
            pfisica.Telefone1 = !string.IsNullOrEmpty(pfisica.Telefone1) ? Regex.Replace(pfisica.Telefone1, "[^0-9]", "") : null;
            pfisica.Telefone2 = !string.IsNullOrEmpty(pfisica.Telefone2) ? Regex.Replace(pfisica.Telefone2, "[^0-9]", "") : null;
            pfisica.Cpf = !string.IsNullOrEmpty(pfisica.Cpf) ? Regex.Replace(pfisica.Cpf, "[^0-9]", "") : null;
            pfisica.Rg = !string.IsNullOrEmpty(pfisica.Rg) ? Regex.Replace(pfisica.Rg, "[^0-9]", "") : null;
            return await _pessoaFisicaRepository.GuardarPessoaFisicaAsync(pfisica);
        }

        public Task<PFisica> PegarPessoaFisicaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PFisica>> PegarPessoasFisicas(CondicaoEnum condicaoEnum)
        {
            return await _pessoaFisicaRepository.PegarPessoasFisicasAsync(condicaoEnum);
        }
    }
}
