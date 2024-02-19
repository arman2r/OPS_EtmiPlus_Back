using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public interface IReporte1Repository
    {
        Reporte1 CreateReporte1(int id, Reporte1 model);
        Reporte1 UpdateReporte1(int id, Reporte1 model);
    }
}
