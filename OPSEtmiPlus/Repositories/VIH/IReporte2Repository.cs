using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public interface IReporte2Repository
    {
        Reporte2 CreateReporte2(int id, Reporte2 model);
        Reporte2 UpdateReporte2(int id, Reporte2 model);
    }
}
