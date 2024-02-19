using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public class DiagnosticoEnfermedadGestanteRepository: IDiagnosticoEnfermedadGestanteRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<DiagnosticoEnfermedadGestanteController> _logger;

        public DiagnosticoEnfermedadGestanteRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<DiagnosticoEnfermedadGestanteController>)logger;
        }

        public DiagnosticoEnfermedadGestanteChagas CreateDiagnosticoGestante(int id, DiagnosticoEnfermedadGestanteChagas model)
        {
            _logger.LogInformation($"Executing repository DiagnosticoGestante to CreateDiagnosticoGestante");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdGestanteControl FROM GestanteControl WHERE IdGestante = @Id";
                    GestanteControl gestanteExist = connection.QueryFirstOrDefault<GestanteControl>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"GestanteControl {id} not was found");
                        throw new Exception($"GestanteControl {id} not was found");
                    }

                    //Assign Id
                    model.IdGestanteControl = id;

                    //Execute insert
                    string query = @"INSERT INTO Chagas_DiagnosticoGestante 
                        (IdGestanteControl, IdCondicionDiagnosticoChagas, EdadGestacionalSemanas, 
                        EdadGestacionalPrimerControlPrentalSemanas, FechaProbableParto)
                    OUTPUT INSERTED.IdDiagnosticoGestante
                    VALUES (@IdGestanteControl, @IdCondicionDiagnosticoChagas, @EdadGestacionalSemanas, 
                            @EdadGestacionalPrimerControlPrentalSemanas, @FechaProbableParto)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"DiagnosticoGestante {model} not was created");
                        throw new Exception($"DiagnosticoGestante {model} not was created");
                    }

                    model.IdDiagnosticoGestante = idInserted;
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
