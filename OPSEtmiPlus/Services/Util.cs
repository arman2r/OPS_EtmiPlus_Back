using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers;
using OPSEtmiPlus.Models;

namespace OPSEtmiPlus.Services
{
    public class Util
    {
        private readonly string? _connectionString;
        private readonly ILogger _logger;

        public Util(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger)logger;
        }

        public Parametrica GetParametricaById(int id)
        {
            _logger.LogInformation($"Executing GetParametricasById {id} from Services");

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
    }
}
