using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public interface ISeguimientoNinoExpuestoChagasRepository
    {
        SeguimientoNinoExpuestoChagas CreateSeguimientoNinoExpuestoChagas(int id, SeguimientoNinoExpuestoChagas model);
    }
}
