using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public class DiagnosticoNinoExpuestoRepository: IDiagnosticoNinoExpuestoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<DiagnosticoNinoExpuestoController> _logger;

        public DiagnosticoNinoExpuestoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<DiagnosticoNinoExpuestoController>)logger;
        }

        public DiagnosticoNinoExpuestoChagas CreateDiagnosticoNinoExpuesto(int id, DiagnosticoNinoExpuestoChagas model)
        {
            _logger.LogInformation($"Executing repository DiagnosticoNinoExpuesto to CreateDiagnosticoNinoExpuesto");

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
                    model.IdGestanteControl = id;

                    //Execute insert
                    string query = @"INSERT INTO Chagas_DiagnosticoNinoExpuesto 
                        (IdGestanteControl, FechaNacimiento, IdExamenParasitologico, ResultadoExamenParasitologico, 
                         FechaRecoleccionMuestra, FechaEmisionResultado, SeHacePruebaDiagnostica3Meses, 
                         IdExamenParasitologico3Meses, ResultadoExamenParasitologico3Meses, FechaRecoleccionMuestra3Meses, 
                         FechaEmisionResultado3Meses, SeHacePrueebaDiagnosticoMolecular, ResultadoPCR, 
                         FechaRecolecionPCR, FechaEmisionPCR, SeHacePruebaDiagnostico10Meses, EsAntigenosTotales, 
                         EsAntigenosRecombinantes, ResultadoPrueba, FechaRecoleccionMuestra10Meses, 
                         FechaEmisionResultado10Meses, EsCasoConfirmadoTMIChagas)
                    OUTPUT INSERTED.IdDiagnosticoNinoExpuesto
                    VALUES (@IdGestanteControl, @FechaNacimiento, @IdExamenParasitologico, 
                            @ResultadoExamenParasitologico, @FechaRecoleccionMuestra, @FechaEmisiónResultado, 
                            @SeHacePruebaDiagnostica3Meses, @IdExamenParasitologico3Meses, 
                            @ResultadoExamenParasitologico3Meses, @FechaRecoleccionMuestra3Meses, 
                            @FechaEmisiónResultado3Meses, @SeHacePrueebaDiagnosticoMolecular, @ResultadoPCR, 
                            @FechaRecolecionPCR, @FechaEmisionPCR, @SeHacePruebaDiagnostico10Meses, 
                            @EsAntigenosTotales, @EsAntigenosRecombinantes, @ResultadoPrueba, 
                            @FechaRecoleccionMuestra10Meses, @FechaEmisionResultado10Meses, 
                            @EsCasoConfirmadoTMIChagas)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"DiagnosticoNinoExpuesto {model} not was created");
                        throw new Exception($"DiagnosticoNinoExpuesto {model} not was created");
                    }

                    model.IdDiagnosticoNinoExpuesto = idInserted;
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
