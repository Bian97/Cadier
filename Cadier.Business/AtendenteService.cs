using Cadier.Abstractions.Interfaces.Repositories;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cadier.Business
{
    public class AtendenteService : IAtendenteService
    {
        private readonly IAtendenteRepository _atendenteRepository;
        public AtendenteService(IAtendenteRepository atendenteRepository)
        {
            _atendenteRepository = atendenteRepository;
        }

        public async Task<bool> LoginAtendenteAsync(string documento, int numero)
        {
            var atendente = await PegarAtendentePorIdAsync(numero);
            if (atendente == null)
                return false;

            if(atendente.DocumentoIdentificacaoSocial.Equals(Regex.Replace(documento, "[^0-9]+", "")))
                return true;
            return false;
        }

        public async Task<Atendente> PegarAtendentePorIdAsync(int id)
        {
            return await _atendenteRepository.PegarAtendentePorIdAsync(id);
        }
    }
}
