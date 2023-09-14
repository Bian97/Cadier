using Cadier.Model.Enums;
using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Services
{
    public interface IPessoaJuridicaService
    {
        Task<PJuridica> PegarPessoaJuridicaPorIdAsync(int id);
        Task<IEnumerable<PJuridica>> PegarPessoasJuridicasAsync(CondicaoEnum condicaoEnum);
        Task<int?> GuardarPessoaJuridicaAsync(PJuridica pjuridica);
        Task<PJuridica> AlterarPessoaJuridicaAsync(PJuridica pjuridica);
    }
}
