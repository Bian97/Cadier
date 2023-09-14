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
    public class HistoricoConsagracaoService : IHistoricoConsagracaoService
    {
        private readonly IHistoricoConsagracaoRepository _historicoConsagracaoRepository;


        public HistoricoConsagracaoService(IHistoricoConsagracaoRepository historicoConsagracaoRepository)
        {
            _historicoConsagracaoRepository = historicoConsagracaoRepository;
        }

        public async Task<int?> GuardarHistoricoConsagracaoAsync(HistoricoConsagracao historicoConsagracao)
        {
            return await _historicoConsagracaoRepository.GuardarHistoricoConsagracaoAsync(historicoConsagracao);
        }
    }
}
