using Cadier.Model.Models;

namespace Cadier.Abstractions.Interfaces.Repositories
{
    public interface ISituacaoCadastralRepository
    {
        Task<SituacaoCadastral> PegarSituacaoCadastralPorIdAsync(int id);
        Task<int?> SalvarSituacaoCadastralAsync(SituacaoCadastral situacaoCadastral);
        Task AlterarSituacaoCadastralAsync(SituacaoCadastral situacaoCadastral);
        Task ApagarSituacaoCadastralPorIdAsync(int id);
    }
}
