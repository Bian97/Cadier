using Cadier.Model.Enums;
using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Services
{
    public interface IPessoaFisicaService
    {
        Task<PFisica> PegarPessoaFisicaPorId(int id);
        Task<IEnumerable<PFisica>> PegarPessoasFisicas(CondicaoEnum condicaoEnum);
        Task<int?> GuardarPessoaFisica(PFisica pfisica);
        Task<PFisica> AlterarPessoaFisica(PFisica pfisica);
    }
}
