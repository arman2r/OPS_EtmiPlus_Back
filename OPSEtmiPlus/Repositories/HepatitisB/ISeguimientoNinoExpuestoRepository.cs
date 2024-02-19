using OPSEtmiPlus.Models.HepatitisB;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public interface ISeguimientoNinoExpuestoRepository
    {
        SeguimientoNinoExpuestoHB CreateSeguimientoNinoExpuesto(int id, SeguimientoNinoExpuestoHB model);
    }
}
