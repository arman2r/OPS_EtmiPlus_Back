using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public interface ITratamientoSeguimientoNinoRepository
    {
        TratamientoSeguimientoNinoChagas CreateTratamientoSeguimientoNino(int id, TratamientoSeguimientoNinoChagas model);
    }
}
