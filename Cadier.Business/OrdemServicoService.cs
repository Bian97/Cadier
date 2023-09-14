using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadier.Business
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        
        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository)
        {
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<int?> GuardarOrdemServicoAsync(OrdemServico ordemServico)
        {
            return await _ordemServicoRepository.GuardarOrdemServicoAsync(ordemServico);
        }
    }
}
