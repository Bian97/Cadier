using Cadier.Model.Enums;
using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Services
{
    public interface IPessoaFisicaService
    {
        Task<PFisica> PegarPessoaFisicaPorId(int id);
        Task<IEnumerable<PFisica>> PegarPessoasFisicas(PFisica pfisica);
        Task<int?> GuardarPessoaFisica(PFisica pfisica);
        Task<PFisica> AlterarPessoaFisica(PFisica pfisica);
        Task<bool> LoginPessoaFisicaAsync(string documento, int numero);
    }
}
