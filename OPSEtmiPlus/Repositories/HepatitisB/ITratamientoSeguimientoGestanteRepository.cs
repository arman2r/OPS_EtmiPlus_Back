using OPSEtmiPlus.Models.HepatitisB;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public interface ITratamientoSeguimientoGestanteRepository
    {
        TratamientoSeguimientoGestanteHB CreateTratamientoSeguimientoGestante(int id, TratamientoSeguimientoGestanteHB model);
    }
}
