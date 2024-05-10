using Cadier.Model.Enums;
using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Repositories
{
    public interface IPessoaFisicaRepository
    {
        Task<PFisica> PegarPessoaFisicaPorIdAsync(int id);
        Task<IEnumerable<PFisica>> PegarPessoasFisicasComFiltrosAsync(PFisica pfisica);
        Task<int?> GuardarPessoaFisicaAsync(PFisica pfisica);
        Task<PFisica> AlterarPessoaFisicaAsync(PFisica pfisica);
    }
}
