using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers;
using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Repositories
{
    public class ParametricaRepository : IParametricaRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<ParametricaController> _logger;

        public ParametricaRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<ParametricaController>)logger;
        }

        public Parametrica GetParametricasById(int id)
        {
            _logger.LogInformation($"Executing repository Parametrica to GetParametricasById {id}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Parametrica WHERE Id = @Id";
                    var model = connection.QueryFirstOrDefault<Parametrica>(query, new { Id = id });

                    if (model == null)
                    {
                        _logger.LogInformation($"Parametrica {id} not was found");
                        throw new Exception($"Parametrica {id} not was found");
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public List<Parametrica> GetParametricasByName(string Name)
        {
            _logger.LogInformation($"Executing repository Parametrica to GetParametricasByName {Name}");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Parametrica WHERE Nombre = @IdName";
                    var list = connection.Query<Parametrica>(query, new { IdName = Name }).ToList();

                    if (list == null)
                    {
                        _logger.LogInformation($"Parametrica {Name} not was found");
                        throw new Exception($"Parametrica {Name} not was found");
                    }
                    return list;
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
