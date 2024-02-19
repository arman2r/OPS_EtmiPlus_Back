using OPSEtmiPlus.Models.Sifilis;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface ISituacionGestanteEmbarazoActualRepository
    {
        SituacionGestanteEmbarazoActual CreateSituacionGestanteEmbarazoActual(int id, SituacionGestanteEmbarazoActual model);
    }
}
