using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.VIH
{
    public class ParaclinicoNinoRepository: IParaclinicoNinoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<ParaclinicoNinoController> _logger;

        public ParaclinicoNinoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<ParaclinicoNinoController>)logger;
        }

        public ParaclinicoNino CreateParaclinicoNino(int id, ParaclinicoNino model)
        {
            _logger.LogInformation($"Executing repository ParaclinicoNino to CreateParaclinicoNino");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdReporte FROM VIH_Reporte5 WHERE IdReporte = @Id";
                    Reporte5 gestanteExist = connection.QueryFirstOrDefault<Reporte5>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"Reporte5 {id} not was found");
                        throw new Exception($"Reporte5 {id} not was found");
                    }

                    //Assign Id
                    model.IdReporte = id;

                    //Execute insert
                    string query = @"INSERT INTO VIH_ParaclinicoNino 
                        (IdReporte, IdParaclinicoRealizado, FechaParaclinico, ResultadoParaclinico)
                    OUTPUT INSERTED.IdParaclinico
                    VALUES (@IdReporte, @IdParaclinicoRealizado, @FechaParaclinico, @ResultadoParaclinico)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"ParaclinicoNino {model} not was created");
                        throw new Exception($"ParaclinicoNino {model} not was created");
                    }

                    model.IdParaclinico = idInserted;
                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public ParaclinicoNino UpdateParaclinicoNino(int id, ParaclinicoNino model)
        {
            _logger.LogInformation($"Executing repository ParaclinicoNino to UpdateParaclinicoNino");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdParaclinico FROM VIH_ParaclinicoNino WHERE IdParaclinico = @Id";
                    ParaclinicoNino gestanteExist = connection.QueryFirstOrDefault<ParaclinicoNino>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"ParaclinicoNino {id} not was found");
                        throw new Exception($"ParaclinicoNino {id} not was found");
                    }

                    //Assign Id
                    model.IdParaclinico = id;

                    //Execute insert
                    string updateQuery = @"
                        UPDATE VIH_ParaclinicoNino
                        SET
                            IdReporte = @IdReporte,
                            IdParaclinicoRealizado = @IdParaclinicoRealizado,
                            FechaParaclinico = @FechaParaclinico,
                            ResultadoParaclinico = @ResultadoParaclinico
                        WHERE
                            IdParaclinico = @IdParaclinico";
                    int affectedRows = connection.Execute(updateQuery, model);

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"ParaclinicoNino {model.IdParaclinico} not was updated");
                        throw new Exception($"ParaclinicoNino {model.IdParaclinico} not was updated");
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
