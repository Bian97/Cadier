using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Models;
using System.Text.RegularExpressions;

namespace Cadier.Business
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
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
            endereco.Cep = !string.IsNullOrEmpty(endereco.Cep) ? Regex.Replace(endereco.Cep, "[^0-9]", "") : null;
            return await _enderecoRepository.SalvarEnderecoAsync(endereco);
        }
    }
}
