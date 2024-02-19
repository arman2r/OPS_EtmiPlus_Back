using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.VIH
{
    public class ParaclinicoMadreRepository: IParaclinicoMadreRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<ParaclinicoMadreController> _logger;

        public ParaclinicoMadreRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<ParaclinicoMadreController>)logger;
        }

        public ParaclinicoMadre CreateParaclinicoMadre(int id, ParaclinicoMadre model)
        {
            _logger.LogInformation($"Executing repository ParaclinicoMadre to CreateParaclinicoMadre");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdReporte FROM VIH_Reporte1 WHERE IdReporte = @Id";
                    Reporte1 gestanteExist = connection.QueryFirstOrDefault<Reporte1>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"Reporte1 {id} not was found");
                        throw new Exception($"Reporte1 {id} not was found");
                    }

                    //Assign Id
                    model.IdReporte = id;

                    //Execute insert
                    string query = @"INSERT INTO VIH_ParaclinicoMadre 
                        (IdReporte, IdMomentoDiagnostico, IdParaclinicoRealizado, FechaParaclinico, ResultadoParaclinico)
                    OUTPUT INSERTED.IdParaclinico
                    VALUES (@IdReporte, @IdMomentoDiagnostico, @IdParaclinicoRealizado, @FechaParaclinico, @ResultadoParaclinico)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"ParaclinicoMadre {model} not was created");
                        throw new Exception($"ParaclinicoMadre {model} not was created");
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

        public ParaclinicoMadre UpdateParaclinicoMadre(int id, ParaclinicoMadre model)
        {
            _logger.LogInformation($"Executing repository ParaclinicoMadre to UpdateParaclinicoMadre");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdParaclinico FROM VIH_ParaclinicoMadre WHERE IdParaclinico = @Id";
                    ParaclinicoMadre gestanteExist = connection.QueryFirstOrDefault<ParaclinicoMadre>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"ParaclinicoMadre {id} not was found");
                        throw new Exception($"ParaclinicoMadre {id} not was found");
                    }

                    //Assign Id
                    model.IdParaclinico = id;

                    //Execute insert
                    string updateQuery = @"
                        UPDATE VIH_ParaclinicoMadre
                        SET
                            IdReporte = @IdReporte,
                            IdMomentoDiagnostico = @IdMomentoDiagnostico,
                            IdParaclinicoRealizado = @IdParaclinicoRealizado,
                            FechaParaclinico = @FechaParaclinico,
                            ResultadoParaclinico = @ResultadoParaclinico
                        WHERE
                            IdParaclinico = @IdParaclinico";
                    int affectedRows = connection.Execute(updateQuery, model);

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"ParaclinicoMadre {model.IdParaclinico} not was updated");
                        throw new Exception($"ParaclinicoMadre {model.IdParaclinico} not was updated");
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
