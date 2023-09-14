using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Enums;
using Cadier.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cadier.Business
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

        public PessoaJuridicaService(IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
        }

        public Task<PJuridica> AlterarPessoaJuridicaAsync(PJuridica pjuridica)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GuardarPessoaJuridicaAsync(PJuridica pjuridica)
        {
            pjuridica.Cnpj = !string.IsNullOrEmpty(pjuridica.Cnpj) ? Regex.Replace(pjuridica.Cnpj, "[^0-9]", "") : null;
            return await _pessoaJuridicaRepository.GuardarPessoaJuridicaAsync(pjuridica);
        }

        public Task<PJuridica> PegarPessoaJuridicaPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PJuridica>> PegarPessoasJuridicasAsync(CondicaoEnum condicaoEnum)
        {
            return await _pessoaJuridicaRepository.PegarPessoasJuridicasAsync(condicaoEnum);
        }
    }
}
