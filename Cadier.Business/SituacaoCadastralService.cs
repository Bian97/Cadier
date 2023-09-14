using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Models;

namespace Cadier.Business
{
    public class SituacaoCadastralService : ISituacaoCadastralService
    {
        private readonly ISituacaoCadastralRepository _situacaoCadastralRepository;

        public SituacaoCadastralService(ISituacaoCadastralRepository situacaoCadastralRepository)
        {
            _situacaoCadastralRepository = situacaoCadastralRepository;
        }

        public Task AlterarSituacaoCadastralAsync(SituacaoCadastral situacaoCadastral)
        {
            throw new NotImplementedException();
        }

        public Task ApagarSituacaoCadastralPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SituacaoCadastral> PegarSituacaoCadastralPorIdAsync(int id)
        {
            return await _situacaoCadastralRepository.PegarSituacaoCadastralPorIdAsync(id);
        }

        public async Task<int?> SalvarSituacaoCadastralAsync(SituacaoCadastral situacaoCadastral)
        {
            return await _situacaoCadastralRepository.SalvarSituacaoCadastralAsync(situacaoCadastral);
        }
    }
}
