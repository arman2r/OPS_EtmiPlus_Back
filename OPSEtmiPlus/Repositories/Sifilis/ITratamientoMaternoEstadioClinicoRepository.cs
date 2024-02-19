using OPSEtmiPlus.Models.Sifilis;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface ITratamientoMaternoEstadioClinicoRepository
    {
        TratamientoMaternoEstadioClinico CreateTratamientoMaternoEstadioClinico(int id, TratamientoMaternoEstadioClinico model);
    }
}
