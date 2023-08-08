using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Enums;
using Cadier.Model.Models;

namespace Cadier.Business
{
    public class PFisicaService : IPFisicaService
    {
        private readonly IPFisicaRepository _pfisicaRepository;

        public PFisicaService(IPFisicaRepository pfisicaRepository) 
        {
            _pfisicaRepository = pfisicaRepository;
        }

        public Task<PFisica> AlterarPFisica(PFisica pfisica)
        {
            throw new NotImplementedException();
        }

        public Task<int> GuardarPFisica(PFisica pfisica)
        {
            throw new NotImplementedException();
        }

        public Task<PFisica> PegarPFisicaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PFisica>> PegarPFisicas(CondicaoEnum condicaoEnum)
        {
            return await _pfisicaRepository.PegarPFisicasAsync(condicaoEnum);
        }
    }
}
