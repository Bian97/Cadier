using Cadier.Model;

namespace Cadier.Abstractions.Interfaces.Repositories
{
    public interface IAtendenteRepository
    {
        Task<Atendente> PegarAtendentePorIdAsync(int id);
    }
}
