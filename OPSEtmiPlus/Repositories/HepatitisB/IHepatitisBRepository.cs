using OPSEtmiPlus.Models.HepatitisB.DTOs;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public interface IHepatitisBRepository
    {
        HepatitisBCompleto GetHepatitisBCompleto(int id);
    }
}
