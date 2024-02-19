using OPSEtmiPlus.Models.Sifilis;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface ISeguimientoContactoSexualRepository
    {
        SeguimientoContactoSexual CreateSeguimientoContactoSexual(int id, SeguimientoContactoSexual model);
    }
}
