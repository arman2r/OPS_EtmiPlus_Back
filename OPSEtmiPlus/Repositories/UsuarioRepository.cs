using Dapper;
using DapperTest.Repositories;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers;
using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Services
{
    public class UsuarioRepository: IUserRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<UsuarioController>)logger;
        }

        public List<Usuario> GetUsers()
        {
            _logger.LogInformation("Executing repository Users to GetUsers");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuario";
                    var data = connection.Query<Usuario>(query).ToList();

                    if (data == null)
                    {
                        _logger.LogInformation($"Table User is empty");
                        throw new Exception($"Table User is empty");
                    }
                    return data;
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);                
            } 
        }

        public Usuario GetById(int id)
        {
            _logger.LogInformation($"Executing repository Users to GetById {id}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuario WHERE Id = @UserId";
                    var user = connection.QueryFirstOrDefault<Usuario>(query, new { UserId = id });

                    if (user == null)
                    {
                        _logger.LogInformation($"User {id} not was found");
                        throw new Exception($"User {id} not was found");            
                    }
                    return user;                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Usuario CreateUser(Usuario user)
        {
            _logger.LogInformation($"Executing repository Usuario to CreateUser {user.Nombre}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Execute insert
                    string query = "INSERT INTO Usuario (Nombre) OUTPUT INSERTED.Id VALUES (@Nombre);";
                    int idInserted = connection.QuerySingle<int>(query, user);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"User {user.Nombre} not was created");
                        throw new Exception($"User {user.Nombre} not was created");                        
                    }

                    user.Id = idInserted;
                    return user;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Usuario UpdateUser(int id, Usuario user)
        {
            _logger.LogInformation($"Executing repository Users to UpdateUser {user.Nombre} with Id: {id}");
            
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Get user first
                    string queryExist = "SELECT * FROM Usuario WHERE id = @UserId";
                    Usuario userExist = connection.QueryFirstOrDefault<Usuario>(queryExist, new { UserId = id })!;

                    if (userExist == null)
                    {
                        _logger.LogInformation($"User {id} not was found");
                        throw new Exception($"User {id} not was found");
                    }

                    //Execute update
                    string updateQuery = "UPDATE Usuario SET name = @Name, age = @Age WHERE id = @Id;";
                    int affectedRows = connection.Execute(updateQuery, user);                    

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"User {user.Nombre} not was updated");
                        throw new Exception($"User {user.Nombre} not was created");                      
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteUser(int id)
        {
            _logger.LogInformation($"Executing repository Users to DeleteUser with Id: {id}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Get user first
                    string queryExist = "DELETE FROM Usuario WHERE id = @UserId";
                    int affectedRows = connection.Execute(queryExist, new { UserId = id })!;                  

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"User {id} not was deleted");
                        throw new Exception($"User {id} not was deleted");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}
