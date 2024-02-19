using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.VIH;
using System.Collections.Generic;

namespace OPSEtmiPlus.Repositories.VIH
{
    public class Reporte5Repository : IReporte5Repository
    {
        private readonly string? _connectionString;
        private readonly ILogger<Reporte5Controller> _logger;

        public Reporte5Repository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<Reporte5Controller>)logger;
        }

        public Reporte5 CreateReporte5(int id, Reporte5 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte5 to CreateReporte4");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdGestanteControl FROM GestanteControl WHERE IdGestanteControl = @Id";
                    GestanteControl gestanteExist = connection.QueryFirstOrDefault<GestanteControl>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"GestanteControl {id} not was found");
                        throw new Exception($"GestanteControl {id} not was found");
                    }

                    //Assign Id
                    reporte.IdGestanteControl = id;

                    //Execute insert
                    string query = @"INSERT INTO VIH_Reporte5 
                        (IdGestanteControl, FechaPruebaRealizadaADNProviral, IdTipoPrueba, FechaPrueba, 
                         ResultadoPrueba, IdTipoAlimentacionNinoExpuesto, IdSituacionNinoExpuesto)
                    OUTPUT INSERTED.IdReporte
                    VALUES (@IdGestanteControl, @FechaPruebaRealizadaADNProviral, @IdTipoPrueba, @FechaPrueba, 
                            @ResultadoPrueba, @IdTipoAlimentacionNinoExpuesto, @IdSituacionNinoExpuesto)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"ClasificacionNinoExpuesto {reporte} not was created");
                        throw new Exception($"ClasificacionNinoExpuesto {reporte} not was created");
                    }

                    reporte.IdReporte = idInserted;
                    return reporte;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Reporte5 UpdateReporte5(int id, Reporte5 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte5 to UpdateReporte5");

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
                    reporte.IdReporte = id;

                    //Execute insert
                    string updateQuery = @"
                        UPDATE VIH_Reporte5
                        SET
                            IdGestanteControl = @IdGestanteControl,
                            FechaPruebaRealizadaADNProviral = @FechaPruebaRealizadaADNProviral,
                            IdTipoPrueba = @IdTipoPrueba,
                            FechaPrueba = @FechaPrueba,
                            ResultadoPrueba = @ResultadoPrueba,
                            IdTipoAlimentacionNinoExpuesto = @IdTipoAlimentacionNinoExpuesto,
                            IdSituacionNinoExpuesto = @IdSituacionNinoExpuesto
                        WHERE
                            IdReporte = @IdReporte";
                    int affectedRows = connection.Execute(updateQuery, reporte);

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"Reporte5 {reporte.IdReporte} not was updated");
                        throw new Exception($"Reporte5 {reporte.IdReporte} not was updated");
                    }

                    return reporte;
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
