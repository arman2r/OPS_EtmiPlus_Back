using OPSEtmiPlus.Models.HepatitisB;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public interface IClasificacionNinoExpuestoRepository
    {
        ClasificacionNinoExpuestoHB CreateClasificacionNinoExpuesto(int id, ClasificacionNinoExpuestoHB model);
    }
}
