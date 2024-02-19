using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.HepatitisB;
using Dapper;
using OPSEtmiPlus.Controllers.HepatitisB;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public class TratamientoSeguimientoGestanteRepository: ITratamientoSeguimientoGestanteRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<TratamientoSeguimientoGestanteController> _logger;

        public TratamientoSeguimientoGestanteRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<TratamientoSeguimientoGestanteController>)logger;
        }

        public TratamientoSeguimientoGestanteHB CreateTratamientoSeguimientoGestante(int id, TratamientoSeguimientoGestanteHB reporte)
        {
            _logger.LogInformation($"Executing repository TratamientoSeguimientoGestante to CreateTratamientoSeguimientoGestante");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdDiagnosticoGestante FROM HB_DiagnosticoGestante WHERE IdDiagnosticoGestante = @Id";
                    DiagnosticoGestanteHB gestanteExist = connection.QueryFirstOrDefault<DiagnosticoGestanteHB>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"DiagnosticoGestante {id} not was found");
                        throw new Exception($"DiagnosticoGestante {id} not was found");
                    }

                    //Assign Id
                    reporte.IdDiagnosticoGestante = id;

                    //Execute insert
                    string query = @"INSERT INTO HB_TratamientoSeguimientoGestante 
                            (IdDiagnosticoGestante, RecibioTratamientoAntesEmbarazoActual, 
                             RequiereTratamientoAntesEmbarazoActual, EdadGestacionalRecibioTratamientoAntesSemana,
                             RequiereTratamientoDuranteEmbarazoActual, EdadGestacionalRecibioTratamientoDuranteSemana,
                             NombreMedicamentoTratamiento, IdSituacionGestante)
                       OUTPUT INSERTED.IdTratamientoSeguimiento
                       VALUES (@IdDiagnosticoGestante, @RecibioTratamientoAntesEmbarazoActual, 
                             @RequiereTratamientoAntesEmbarazoActual, @EdadGestacionalRecibioTratamientoAntesSemana,
                             @RequiereTratamientoDuranteEmbarazoActual, @EdadGestacionalRecibioTratamientoDuranteSemana,
                             @NombreMedicamentoTratamiento, @IdSituacionGestante)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"TratamientoSeguimientoGestante {reporte} not was created");
                        throw new Exception($"TratamientoSeguimientoGestante {reporte} not was created");
                    }

                    reporte.IdTratamientoSeguimiento = idInserted;
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
