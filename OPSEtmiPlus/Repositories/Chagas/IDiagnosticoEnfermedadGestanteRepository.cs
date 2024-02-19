using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public interface IDiagnosticoEnfermedadGestanteRepository
    {
        DiagnosticoEnfermedadGestanteChagas CreateDiagnosticoGestante(int id, DiagnosticoEnfermedadGestanteChagas model);
    }
}
