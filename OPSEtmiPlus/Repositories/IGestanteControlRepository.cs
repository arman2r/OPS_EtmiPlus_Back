using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Repositories
{
    public interface IGestanteControlRepository
    {
        ControlEstadoFichas GetEstadoFichas(int id);
        List<GestanteControl> GetGestanteControlByIdGestante(int id);
        GestanteControl CreateGestanteControl(int id, GestanteControl model);
    }
}
