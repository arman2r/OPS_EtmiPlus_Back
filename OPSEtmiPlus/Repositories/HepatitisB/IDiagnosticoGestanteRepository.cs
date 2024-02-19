using OPSEtmiPlus.Models.HepatitisB;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public interface IDiagnosticoGestanteRepository
    {
        DiagnosticoGestanteHB CreateDiagnosticoGestante(int id, DiagnosticoGestanteHB model);
    }
}
