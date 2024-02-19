using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Repositories
{
    public interface IReporteBinomioRepository
    {
        ReporteBinomio GetByIdGestanteControl(int id);
        ReporteBinomio CreateReporteBinomio(int id, ReporteBinomio reporte);
    }
}
