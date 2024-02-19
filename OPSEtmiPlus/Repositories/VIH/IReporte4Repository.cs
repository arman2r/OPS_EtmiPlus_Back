using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public interface IReporte4Repository
    {
        Reporte4 CreateReporte4(int id, Reporte4 model);
        Reporte4 UpdateReporte4(int id, Reporte4 model);
    }
}
