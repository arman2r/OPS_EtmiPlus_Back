using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class RetratamientoMaternoGestacionalRepository: IRetratamientoMaternoGestacionalRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<RetratamientoMaternoGestacionalController> _logger;

        public RetratamientoMaternoGestacionalRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<RetratamientoMaternoGestacionalController>)logger;
        }

        public RetratamientoMaternoGestacional CreateRetratamientoMaternoGestacional(int id, RetratamientoMaternoGestacional model)
        {
            _logger.LogInformation($"Executing repository RetratamientoMaternoGestacional to CreateRetratamientoMaternoGestacional");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdTratamientoMaternoEstadioClinico FROM Sifilis_TratamientoMaternoEstadioClinico WHERE IdTratamientoMaternoEstadioClinico = @Id";
                    TratamientoMaternoEstadioClinico idExist = connection.QueryFirstOrDefault<TratamientoMaternoEstadioClinico>(queryExist, new { Id = id })!;

                    if (idExist == null)
                    {
                        _logger.LogInformation($"TratamientoMaternoEstadioClinico {id} not was found");
                        throw new Exception($"TratamientoMaternoEstadioClinico {id} not was found");
                    }

                    //Assign Id
                    model.IdTratamientoMaternoEstadioClinico = id;

                    //Execute insert
                    string query = @"INSERT INTO Sifilis_RetratamientoMaternoGestacional
                        (IdTratamientoMaternoEstadioClinico, RequirioTratamiento, IdCausaRetratamiento, AplicaronPenicilinaBenzatinica)
                    OUTPUT INSERTED.IdRetratamientoMaternoGestacional
                    VALUES
                        (@IdTratamientoMaternoEstadioClinico, @RequirioTratamiento, @IdCausaRetratamiento, @AplicaronPenicilinaBenzatinica)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"RetratamientoMaternoGestacional {model} not was created");
                        throw new Exception($"RetratamientoMaternoGestacional {model} not was created");
                    }

                    model.IdRetratamientoMaternoGestacional = idInserted;
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
