using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.DTOs;

namespace OPSEtmiPlus.Repositories
{
    public interface IGestanteRepository
    {
        Gestante GetGestanteById(int id);
        DataPaginated<Gestante> GetGestantes(string? filter, int page, int limit);
        Gestante CreateGestante(Gestante model);
        Gestante UpdateGestante(int id, Gestante model);
    }
}
