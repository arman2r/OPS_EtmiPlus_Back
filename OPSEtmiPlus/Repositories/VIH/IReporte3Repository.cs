using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public interface IReporte3Repository
    {
        Reporte3 CreateReporte3(int id, Reporte3 model);
        Reporte3 UpdateReporte3(int id, Reporte3 model);
    }
}
