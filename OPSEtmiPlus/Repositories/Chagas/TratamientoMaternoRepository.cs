using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Models.Chagas;
using Dapper;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public class TratamientoMaternoRepository: ITratamientoMaternoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<TratamientoMaternoController> _logger;

        public TratamientoMaternoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<TratamientoMaternoController>)logger;
        }

        public TratamientoMaternoChagas CreateTratamientoMaterno(int id, TratamientoMaternoChagas model)
        {
            _logger.LogInformation($"Executing repository TratamientoMaterno to CreateTratamientoMaterno");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdAlgoritmo FROM Chagas_Algoritmo WHERE IdAlgoritmo = @Id";
                    AlgoritmoChagas gestanteExist = connection.QueryFirstOrDefault<AlgoritmoChagas>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"Algoritmo {id} not was found");
                        throw new Exception($"Algoritmo {id} not was found");
                    }

                    //Assign Id
                    model.IdAlgoritmo = id;

                    //Execute insert
                    string query = @"INSERT INTO Chagas_TratamientoMaterno 
                        (IdAlgoritmo, BenznidazolX60Dias, FechaInicioTratamiento, NufurtimoxX60Dias, 
                         IdNufurtimoxControlesMedicos, FinalizacionLactanciaMaterna, 
                         MetodoAnticonceptivoUtilizadoDuranteTratamiento)
                    OUTPUT INSERTED.IdTratamientoMaterno
                    VALUES (@IdAlgoritmo, @BenznidazolX60Dias, @FechaInicioTratamiento, 
                            @NufurtimoxX60Dias, @IdNufurtimoxControlesMedicos, 
                            @FinalizacionLactanciaMaterna, @MetodoAnticonceptivoUtilizadoDuranteTratamiento)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"TratamientoMaterno {model} not was created");
                        throw new Exception($"TratamientoMaterno {model} not was created");
                    }

                    model.IdTratamientoMaterno = idInserted;
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
