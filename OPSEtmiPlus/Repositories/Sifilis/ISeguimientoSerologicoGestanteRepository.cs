using OPSEtmiPlus.Models.Sifilis;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface ISeguimientoSerologicoGestanteRepository
    {
        SeguimientoSerologicoGestante CreateSeguimientoSerologicoGestante(int id, SeguimientoSerologicoGestante model);
    }
}
