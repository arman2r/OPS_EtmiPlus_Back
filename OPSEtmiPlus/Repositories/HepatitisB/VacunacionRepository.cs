using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.HepatitisB;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public class VacunacionRepository: IVacunacionRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<VacunacionController> _logger;

        public VacunacionRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<VacunacionController>)logger;
        }

        public VacunacionHB CreateVacunacion(int id, VacunacionHB model)
        {
            _logger.LogInformation($"Executing repository Vacunacion to CreateVacunacion");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdSeguimientoNinoExpuesto FROM HB_SeguimientoNinoExpuesto WHERE IdSeguimientoNinoExpuesto = @Id";
                    SeguimientoNinoExpuestoHB gestanteExist = connection.QueryFirstOrDefault<SeguimientoNinoExpuestoHB>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"SeguimientoNinoExpuestoHB {id} not was found");
                        throw new Exception($"SeguimientoNinoExpuestoHB {id} not was found");
                    }

                    //Assign Id
                    model.IdSeguimientoNinoExpuesto = id;

                    //Execute insert
                    string query = @"INSERT INTO HB_Vacunacion 
                        (IdSeguimientoNinoExpuesto, IdDosisVacuna, FechaAplicacion)
                    OUTPUT INSERTED.IdVacuna
                    VALUES (@IdSeguimientoNinoExpuesto, @IdDosisVacuna, @FechaAplicacion)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"Vacunacion {model} not was created");
                        throw new Exception($"Vacunacion {model} not was created");
                    }

                    model.IdVacuna = idInserted;
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
