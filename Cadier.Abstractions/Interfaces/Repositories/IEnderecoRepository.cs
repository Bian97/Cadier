using Cadier.Model.Models;
using System.Threading.Tasks;

namespace Cadier.Abstractions.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task<Endereco> PegarEnderecoPorIdAsync(int id);
        Task<int?> SalvarEnderecoAsync(Endereco endereco);
        Task AlterarEnderecoAsync(Endereco endereco);
        Task ApagarEnderecoPorIdAsync(int id);
    }
}
