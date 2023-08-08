using Cadier.Model.Enums;
using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Services
{
    public interface IPFisicaService
    {
        Task<PFisica> PegarPFisicaPorId(int id);
        Task<IEnumerable<PFisica>> PegarPFisicas(CondicaoEnum condicaoEnum);
        Task<int> GuardarPFisica(PFisica pfisica);
        Task<PFisica> AlterarPFisica(PFisica pfisica);
    }
}
