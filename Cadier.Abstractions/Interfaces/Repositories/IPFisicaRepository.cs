using Cadier.Model.Enums;
using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Repositories
{
    public interface IPFisicaRepository
    {
        Task<PFisica> PegarPFisicaPorIdAsync(int id);
        Task<IEnumerable<PFisica>> PegarPFisicasAsync(CondicaoEnum condicaoEnum);
        Task<int> GuardarPFisicaAsync(PFisica pfisica);
        Task<PFisica> AlterarPFisicaAsync(PFisica pfisica);
    }
}
