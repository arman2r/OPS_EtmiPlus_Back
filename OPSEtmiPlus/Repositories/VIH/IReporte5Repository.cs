using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public interface IReporte5Repository
    {
        Reporte5 CreateReporte5(int id, Reporte5 model);
        Reporte5 UpdateReporte5(int id, Reporte5 model);
    }
}
