using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Services
{
    public interface IEnderecoService
    {
        Task<Endereco> PegarEnderecoPorIdAsync(int id);
        Task<int?> SalvarEnderecoAsync(Endereco endereco);
        Task AlterarEnderecoAsync(Endereco endereco);
        Task ApagarEnderecoPorIdAsync(int id);
    }
}
