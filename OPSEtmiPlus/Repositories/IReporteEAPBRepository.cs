using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Repositories
{
    public interface IReporteEAPBRepository
    {
        ReporteEAPB GetByIdGestanteControl(int id);
        ReporteEAPB CreateReporteEAPB(int id, ReporteEAPB reporte);
    }
}
