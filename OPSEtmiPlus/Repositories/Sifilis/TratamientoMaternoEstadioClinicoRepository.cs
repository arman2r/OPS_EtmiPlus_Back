using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Sifilis
{
    public class TratamientoMaternoEstadioClinicoRepository: ITratamientoMaternoEstadioClinicoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<TratamientoMaternoEstadioClinicoController> _logger;

        public TratamientoMaternoEstadioClinicoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<TratamientoMaternoEstadioClinicoController>)logger;
        }

        public TratamientoMaternoEstadioClinico CreateTratamientoMaternoEstadioClinico(int id, TratamientoMaternoEstadioClinico tratamiento)
        {
            _logger.LogInformation($"Executing repository TratamientoMaternoEstadioClinico to CreateTratamientoMaternoEstadioClinico");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdDiagnosticoMaterno FROM Sifilis_DiagnosticoMaterno WHERE IdDiagnosticoMaterno = @Id";
                    DiagnosticoMaterno gestanteExist = connection.QueryFirstOrDefault<DiagnosticoMaterno>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"DiagnosticoMaterno {id} not was found");
                        throw new Exception($"DiagnosticoMaterno {id} not was found");
                    }

                    //Assign Id
                    tratamiento.IdDiagnosticoMaterno = id;

                    //Execute insert
                    string query = @"INSERT INTO Sifilis_TratamientoMaternoEstadioClinico 
                        (IdDiagnosticoMaterno, IdClasificacionEstadioClinico, AplicaronPenicilinaBenzatinica, 
                         IdResultadoManejoSifilisGestacional, SeRealizoDesensibilizacionAplicacionPenicilinaBenzatinica, 
                         IdResultadoPrevenirSifilisCongenita)
                    OUTPUT INSERTED.IdTratamientoMaternoEstadioClinico
                    VALUES (@IdDiagnosticoMaterno, @IdClasificacionEstadioClinico, @AplicaronPenicilinaBenzatinica, 
                            @IdResultadoManejoSifilisGestacional, @SeRealizoDesensibilizacionAplicacionPenicilinaBenzatinica, 
                            @IdResultadoPrevenirSifilisCongenita)";
                    int idInserted = connection.QuerySingle<int>(query, tratamiento);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"TratamientoMaternoEstadioClinico {tratamiento} not was created");
                        throw new Exception($"TratamientoMaternoEstadioClinico {tratamiento} not was created");
                    }

                    tratamiento.IdTratamientoMaternoEstadioClinico = idInserted;
                    return tratamiento;
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
