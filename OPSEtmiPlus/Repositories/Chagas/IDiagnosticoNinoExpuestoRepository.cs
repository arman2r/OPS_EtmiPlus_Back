using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public interface IDiagnosticoNinoExpuestoRepository
    {
        DiagnosticoNinoExpuestoChagas CreateDiagnosticoNinoExpuesto(int id, DiagnosticoNinoExpuestoChagas model);
    }
}
