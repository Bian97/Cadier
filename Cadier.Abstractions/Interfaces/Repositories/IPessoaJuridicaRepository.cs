using Cadier.Model.Enums;
using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Services
{
    public interface IPessoaJuridicaRepository
    {
        Task<PJuridica> PegarPessoaJuridicaPorIdAsync(int id);
        Task<IEnumerable<PJuridica>> PegarPessoasJuridicasAsync(CondicaoEnum condicaoEnum);
        Task<int?> GuardarPessoaJuridicaAsync(PJuridica pessoaJuridica);
        Task<PJuridica> AlterarPessoaJuridicaAsync(PJuridica pessoaJuridica);
    }
}
