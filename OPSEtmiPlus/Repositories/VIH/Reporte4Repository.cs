using Dapper;
using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models;
using OPSEtmiPlus.Models.VIH;

namespace OPSEtmiPlus.Repositories.VIH
{
    public class Reporte4Repository : IReporte4Repository
    {
        private readonly string? _connectionString;
        private readonly ILogger<Reporte4Controller> _logger;

        public Reporte4Repository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<Reporte4Controller>)logger;
        }

        public Reporte4 CreateReporte4(int id, Reporte4 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte4 to CreateReporte4");

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
                    string query = @"INSERT INTO VIH_Reporte4 
                        (IdGestanteControl, IdTipoRegimenSalud, NombreAseguradora, NombresApellidos, IdTipoDocumento, 
                         NumeroIdentificacion, IdClasificacionTMINinoExpuesto, RecibioNinoProfilaxisAntiretroviral, 
                         MedicamentosAntirretroviralNinoExpuesto, SeRealizoADNProviral, FechaResultadoADNProviral, 
                         ResultadoADNProviral, SeRealizaronCargasVirales, FechaResultadoCargasVirales, 
                         ResultadoCargasVirales, OtrasPruebasNinoExpuesto)
                    OUTPUT INSERTED.IdReporte
                    VALUES (@IdGestanteControl, @IdTipoRegimenSalud, @NombreAseguradora, @NombresApellidos, 
                            @IdTipoDocumento, @NumeroIdentificacion, @IdClasificacionTMINinoExpuesto, 
                            @RecibioNinoProfilaxisAntiretroviral, @MedicamentosAntirretroviralNinoExpuesto, 
                            @SeRealizoADNProviral, @FechaResultadoADNProviral, @ResultadoADNProviral, 
                            @SeRealizaronCargasVirales, @FechaResultadoCargasVirales, @ResultadoCargasVirales, 
                            @OtrasPruebasNinoExpuesto)";
                    int idInserted = connection.QuerySingle<int>(query, reporte);

                    if (idInserted <= 0)
                    {
                        _logger.LogError($"Reporte4 {reporte} not was created");
                        throw new Exception($"Reporte4 {reporte} not was created");
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

        public Reporte4 UpdateReporte4(int id, Reporte4 reporte)
        {
            _logger.LogInformation($"Executing repository Reporte4 to UpdateReporte4");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    //Validations
                    string queryExist = "SELECT IdReporte FROM VIH_Reporte5 WHERE IdReporte = @Id";
                    Reporte4 gestanteExist = connection.QueryFirstOrDefault<Reporte4>(queryExist, new { Id = id })!;

                    if (gestanteExist == null)
                    {
                        _logger.LogInformation($"Reporte4 {id} not was found");
                        throw new Exception($"Reporte4 {id} not was found");
                    }

                    //Assign Id
                    reporte.IdReporte = id;

                    //Execute insert
                    string updateQuery = @"
                        UPDATE VIH_Reporte4
                        SET
                            IdGestanteControl = @IdGestanteControl,
                            IdTipoRegimenSalud = @IdTipoRegimenSalud,
                            NombreAseguradora = @NombreAseguradora,
                            NombresApellidos = @NombresApellidos,
                            IdTipoDocumento = @IdTipoDocumento,
                            NumeroIdentificacion = @NumeroIdentificacion,
                            IdClasificacionTMINinoExpuesto = @IdClasificacionTMINinoExpuesto,
                            RecibioNinoProfilaxisAntiretroviral = @RecibioNinoProfilaxisAntiretroviral,
                            MedicamentosAntirretroviralNinoExpuesto = @MedicamentosAntirretroviralNinoExpuesto,
                            SeRealizoADNProviral = @SeRealizoADNProviral,
                            FechaResultadoADNProviral = @FechaResultadoADNProviral,
                            ResultadoADNProviral = @ResultadoADNProviral,
                            SeRealizaronCargasVirales = @SeRealizaronCargasVirales,
                            FechaResultadoCargasVirales = @FechaResultadoCargasVirales,
                            ResultadoCargasVirales = @ResultadoCargasVirales,
                            OtrasPruebasNinoExpuesto = @OtrasPruebasNinoExpuesto
                        WHERE
                            IdReporte = @IdReporte";
                    int affectedRows = connection.Execute(updateQuery, reporte);

                    if (affectedRows <= 0)
                    {
                        _logger.LogError($"Reporte4 {reporte.IdReporte} not was updated");
                        throw new Exception($"Reporte24{reporte.IdReporte} not was updated");
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
