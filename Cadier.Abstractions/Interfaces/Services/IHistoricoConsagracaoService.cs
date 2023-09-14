using Cadier.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadier.Abstractions.Interfaces.Services
{
    public interface IHistoricoConsagracaoService
    {
        Task<int?> GuardarHistoricoConsagracaoAsync(HistoricoConsagracao historicoConsagracao);
    }
}
