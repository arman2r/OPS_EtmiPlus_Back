using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public class Reporte1Repository : IReporte1Repository
    {
        private readonly string? _connectionString;
        private readonly ILogger<Reporte1Controller> _logger;

        public Reporte1Repository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<Reporte1Controller>)logger;
        }

        public Reporte1 CreateReporte1(int id, Reporte1 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte1 to CreateReporte1");

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
                    string query = @"INSERT INTO VIH_Reporte1 
                        (IdGestanteControl, IdMomentoDiagnostico, IdPruebaConfirmarVih, FechaDiagnostico, IdResultados, 
                         NumeroCopias, EstabaRecibiendoTARAntesEmbarazo, RecibioTARDuranteEmbarazo, EdadGestacionalInicioTARSemanas, 
                         EstabaRecibiendoTARDuranteEmbarazoActual, EdadGestacionalCuandoRecibioTAR, 
                         EdadGestacionalAlDianosticoVIHSemanas, MedicamentosARVSuministrados, 
                         SeRealizoControlPrenatalDuranteEmbarazo, EdadGestacionalPrimerControlPrenatalSemanas, FechaProbableParto)
                    OUTPUT INSERTED.IdReporte
                    VALUES (@IdGestanteControl, @IdMomentoDiagnostico, @IdPruebaConfirmarVih, @FechaDiagnostico, @IdResultados, 
                            @NumeroCopias, @EstabaRecibiendoTARAntesEmbarazo, @RecibioTARDuranteEmbarazo, @EdadGestacionalInicioTARSemanas, 
                            @EstabaRecibiendoTARDuranteEmbarazoActual, @EdadGestacionalCuandoRecibioTAR, 
                            @EdadGestacionalAlDianosticoVIHSemanas, @MedicamentosARVSuministrados, 
                            @SeRealizoControlPrenatalDuranteEmbarazo, @EdadGestacionalPrimerControlPrenatalSemanas, @FechaProbableParto)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"Reporte1 {reporte} not was created");
                        throw new Exception($"Reporte1 {reporte} not was created");
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

        public Reporte1 UpdateReporte1(int id, Reporte1 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte1 to UpdateReporte1");

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
                    reporte.IdReporte = id;

                    //Execute insert
                    string updateQuery = @"
                        UPDATE VIH_Reporte1
                        SET
                            IdGestanteControl = @IdGestanteControl,
                            IdMomentoDiagnostico = @IdMomentoDiagnostico,
                            IdPruebaConfirmarVih = @IdPruebaConfirmarVih,
                            FechaDiagnostico = @FechaDiagnostico,
                            IdResultados = @IdResultados,
                            NumeroCopias = @NumeroCopias,
                            EstabaRecibiendoTARAntesEmbarazo = @EstabaRecibiendoTARAntesEmbarazo,
                            RecibioTARDuranteEmbarazo = @RecibioTARDuranteEmbarazo,
                            EdadGestacionalInicioTARSemanas = @EdadGestacionalInicioTARSemanas,
                            EstabaRecibiendoTARDuranteEmbarazoActual = @EstabaRecibiendoTARDuranteEmbarazoActual,
                            EdadGestacionalCuandoRecibioTAR = @EdadGestacionalCuandoRecibioTAR,
                            EdadGestacionalAlDianosticoVIHSemanas = @EdadGestacionalAlDianosticoVIHSemanas,
                            MedicamentosARVSuministrados = @MedicamentosARVSuministrados,
                            SeRealizoControlPrenatalDuranteEmbarazo = @SeRealizoControlPrenatalDuranteEmbarazo,
                            EdadGestacionalPrimerControlPrenatalSemanas = @EdadGestacionalPrimerControlPrenatalSemanas,
                            FechaProbableParto = @FechaProbableParto
                        WHERE
                            IdReporte = @IdReporte";
                    int affectedRows = connection.Execute(updateQuery, reporte);

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"Reporte1 {reporte.IdReporte} not was updated");
                        throw new Exception($"Reporte1 {reporte.IdReporte} not was updated");
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
