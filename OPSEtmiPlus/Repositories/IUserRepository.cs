using OPSEtmiPlus.Models;

namespace DapperTest.Repositories
{
    public interface IUserRepository
    {
        List<Usuario> GetUsers();
        Usuario GetById(int id);
        Usuario CreateUser(Usuario user);
        Usuario UpdateUser(int id, Usuario user);
        bool DeleteUser(int id);
    }
}
