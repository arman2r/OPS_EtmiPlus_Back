using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class DiagnosticoMaternoRepository: IDiagnosticoMaternoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<DiagnosticoMaternoController> _logger;

        public DiagnosticoMaternoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<DiagnosticoMaternoController>)logger;
        }

        public DiagnosticoMaterno CreateDiagnosticoMaterno(int id, DiagnosticoMaterno model)
        {
            _logger.LogInformation($"Executing repository DiagnosticoMaterno to CreateDiagnosticoMaterno");

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
                    string query = @"INSERT INTO Sifilis_DiagnosticoMaterno 
                        (IdGestanteControl, IdMomentoDiagnostico, EdadGestacionalDuranteSemanas, 
                         SeRealizoControlPrenatalDuranteEmbarazo, SeRealizoPruebaTreponemica, 
                         IdPruebaTreponemica, IdResultadoPruebaTreponemica, FechaResultadoPruebaTreponemica, 
                         EdadGestacionalALaRealizacionPruebaTreponemicaSemanas, SeRealizoPruebaNoTreponemica, 
                         IdPruebaNoTreponemica, IdResultadoPruebaNoTreponemica, FechaResultadoPruebaNoTreponemica, 
                         ReporteDilucionesPruebaNoTreponemicaReactiva)
                    OUTPUT INSERTED.IdDiagnosticoMaterno
                    VALUES (@IdGestanteControl, @IdMomentoDiagnostico, @EdadGestacionalDuranteSemanas, 
                            @SeRealizoControlPrenatalDuranteEmbarazo, @SeRealizoPruebaTreponemica, 
                            @IdPruebaTreponemica, @IdResultadoPruebaTreponemica, @FechaResultadoPruebaTreponemica, 
                            @EdadGestacionalALaRealizacionPruebaTreponemicaSemanas, @SeRealizoPruebaNoTreponemica, 
                            @IdPruebaNoTreponemica, @IdResultadoPruebaNoTreponemica, @FechaResultadoPruebaNoTreponemica, 
                            @ReporteDilucionesPruebaNoTreponemicaReactiva)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"DiagnosticoMaterno {model} not was created");
                        throw new Exception($"DiagnosticoMaterno {model} not was created");
                    }

                    model.IdDiagnosticoMaterno = idInserted;
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
