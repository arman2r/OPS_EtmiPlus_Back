using OPSEtmiPlus.Models.Sifilis;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface IAplicacionPenicilinaBenzatinicaRepository
    {
        AplicacionPenicilinaBenzatinica CreateAplicacionPenicilinaBenzatinica(int? idTratamiento, int? idRetratamiento, int? idSeguimiento, AplicacionPenicilinaBenzatinica model);
    }
}
