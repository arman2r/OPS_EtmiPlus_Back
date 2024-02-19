using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models;
using Dapper;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public class SeguimientoNinoExpuestoChagasRepository: ISeguimientoNinoExpuestoChagasRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<SeguimientoNinoExpuestoChagasController> _logger;

        public SeguimientoNinoExpuestoChagasRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<SeguimientoNinoExpuestoChagasController>)logger;
        }

        public SeguimientoNinoExpuestoChagas CreateSeguimientoNinoExpuestoChagas(int id, SeguimientoNinoExpuestoChagas model)
        {
            _logger.LogInformation($"Executing repository SeguimientoNinoExpuestoChagas to CreateSeguimientoNinoExpuestoChagas");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdDiagnosticoNinoExpuesto FROM Chagas_DiagnosticoNinoExpuesto WHERE IdDiagnosticoNinoExpuesto = @Id";
                    DiagnosticoNinoExpuestoChagas gestanteExist = connection.QueryFirstOrDefault<DiagnosticoNinoExpuestoChagas>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"GestanteControl {id} not was found");
                        throw new Exception($"GestanteControl {id} not was found");
                    }

                    //Assign Id
                    model.IdDiagnosticoNinoExpuesto = id;

                    //Execute insert
                    string query = @"INSERT INTO Chagas_SeguimientoNinoExpuesto 
                        (IdDiagnosticoNinoExpuesto, FechaNacimiento, IdCondicionRecienNacido, 
                         IdNumeroProductosNacimiento, EdadGestacionalNacimientoSemanas, PesoGramos, 
                         IdSexo, IdTipoParto, IdTipoRegimenSalud, NombreAseguradoraEAPB, 
                         NombresApellidos, IdTipoDocumento, NumeroIdentificacion)
                    OUTPUT INSERTED.IdSeguimientoNinoExpuesto
                    VALUES (@IdDiagnosticoNinoExpuesto, @FechaNacimiento, @IdCondicionRecienNacido, 
                            @IdNumeroProductosNacimiento, @EdadGestacionalNacimientoSemanas, @PesoGramos, 
                            @IdSexo, @IdTipoParto, @IdTipoRegimenSalud, @NombreAseguradoraEAPB, 
                            @NombresApellidos, @IdTipoDocumento, @NumeroIdentificacion)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"SeguimientoNinoExpuestoChagas {model} not was created");
                        throw new Exception($"SeguimientoNinoExpuestoChagas {model} not was created");
                    }

                    model.IdSeguimientoNinoExpuesto = idInserted;
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
