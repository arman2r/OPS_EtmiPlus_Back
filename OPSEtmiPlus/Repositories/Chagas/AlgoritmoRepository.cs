using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Models.Chagas;

namespace OPSEtmiPlus.Repositories.Chagas
{
    public class AlgoritmoRepository: IAlgoritmoRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<AlgoritmoController> _logger;

        public AlgoritmoRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<AlgoritmoController>)logger;
        }

        public AlgoritmoChagas CreateAlgoritmo(int id, AlgoritmoChagas model)
        {
            _logger.LogInformation($"Executing repository Algoritmo to CreateAlgoritmo");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdDiagnosticoGestante FROM Chagas_DiagnosticoGestante WHERE IdDiagnosticoGestante = @Id";
                    DiagnosticoEnfermedadGestanteChagas gestanteExist = connection.QueryFirstOrDefault<DiagnosticoEnfermedadGestanteChagas>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"DiagnosticoGestante {id} not was found");
                        throw new Exception($"DiagnosticoGestante {id} not was found");
                    }

                    //Assign Id
                    model.IdDiagnosticoGestante = id;

                    //Execute insert
                    string query = @"INSERT INTO Chagas_Algoritmo 
                        (IdDiagnosticoGestante, SospechaChagasAgudo, IdExamenParasitologico, ResultadoExamenParasitologico, 
                         SospechaChagasCronicoOTamizajeControlPrenatal, 
                         ResultadoPruebaTamizajeElisaAntigenosTotales, FechaRecoleccionMuestraElisaAntigenosTotales, 
                         FechaEmisionResultadoElisaAntigenosTotales, 
                         ResultadoPruebaTamizajeElisaAntigenosRecombinantes1, FechaRecoleccionMuestraRecombinantes1, 
                         FechaEmisionResultadoRecombinantes1, 
                         ResultadoPruebaTamizajeInmunocromatografia, FechaRecoleccionMuestraInmunocromatografia, 
                         FechaEmisionInmunocromatografia, 
                         ResultadoPruebaTamizajeElisaAntigenosRecombinantes2, FechaRecoleccionMuestraRecombinantes2, 
                         FechaEmisionResultadoRecombinantes2, 
                         TipoPruebaUtilizada, ResultadoPruebaUtilizada, FechaRecoleccionMuestraNoConcordante, 
                         FechaEmisionNoConcordante, ResultadoPruebaTamizajeElisaAntigenosRecombinantes3, 
                         FechaRecoleccionMuestraRecombinantes3, FechaEmisionResultadoRecombinantes3, 
                         EsConfirmadoGestanteConChagas, EsDescartadoGestanteConChagas, 
                         NumeroHijosDiferenteAlEmbarazoParaRealizarDiagnosticoChagas)
                    OUTPUT INSERTED.IdAlgoritmo
                    VALUES (@IdDiagnosticoGestante, @SospechaChagasAgudo, @IdExamenParasitologico, @ResultadoExamenParasitologico, 
                            @SospechaChagasCronicoOTamizajeControlPrenatal, 
                            @ResultadoPruebaTamizajeElisaAntigenosTotales, @FechaRecoleccionMuestraElisaAntigenosTotales, 
                            @FechaEmisionResultadoElisaAntigenosTotales, 
                            @ResultadoPruebaTamizajeElisaAntigenosRecombinantes1, @FechaRecoleccionMuestraRecombinantes1, 
                            @FechaEmisionResultadoRecombinantes1, 
                            @ResultadoPruebaTamizajeInmunocromatografia, @FechaRecoleccionMuestraInmunocromatografia, 
                            @FechaEmisionInmunocromatografia, 
                            @ResultadoPruebaTamizajeElisaAntigenosRecombinantes2, @FechaRecoleccionMuestraRecombinantes2, 
                            @FechaEmisionResultadoRecombinantes2, 
                            @TipoPruebaUtilizada, @ResultadoPruebaUtilizada, @FechaRecoleccionMuestraNoConcordante, 
                            @FechaEmisionNoConcordante, @ResultadoPruebaTamizajeElisaAntigenosRecombinantes3, 
                            @FechaRecoleccionMuestraRecombinantes3, @FechaEmisionResultadoRecombinantes3, 
                            @EsConfirmadoGestanteConChagas, @EsDescartadoGestanteConChagas, 
                            @NumeroHijosDiferenteAlEmbarazoParaRealizarDiagnosticoChagas)";
                    int idInserted = connection.QuerySingle<int>(query, model);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"Algoritmo {model} not was created");
                        throw new Exception($"Algoritmo {model} not was created");
                    }

                    model.IdAlgoritmo = idInserted;
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

