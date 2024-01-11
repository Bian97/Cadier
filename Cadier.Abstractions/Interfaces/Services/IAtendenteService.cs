using Cadier.Model;

namespace Cadier.Abstractions.Interfaces.Services
{
    public interface IAtendenteService
    {
        Task<Atendente> PegarAtendentePorIdAsync(int id);
        Task<bool> LoginAtendenteAsync(string documento, int numero);
    }
}
