using OPSEtmiPlus.Models.Sifilis.DTOs;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public interface ISifilisRepository
    {
        SifilisCompleto GetSifilisCompleto(int id);
    }
}
