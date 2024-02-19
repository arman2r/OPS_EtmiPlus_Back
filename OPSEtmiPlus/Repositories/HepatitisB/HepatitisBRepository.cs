using Microsoft.Data.SqlClient;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Models.VIH.DTOs;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Services;
using OPSEtmiPlus.Models.HepatitisB.DTOs;
using OPSEtmiPlus.Controllers.HepatitisB;
using OPSEtmiPlus.Models.HepatitisB;
using Dapper;

namespace OPSEtmiPlus.Repositories.HepatitisB
{
    public class HepatitisBRepository: IHepatitisBRepository
    {
        private readonly string? _connectionString;
        private readonly ILogger<HepatitisBController> _logger;

        public HepatitisBRepository(ILogger logger, string connectionString)
        {
            _connectionString = connectionString;
            _logger = (ILogger<HepatitisBController>)logger;
        }

        public HepatitisBCompleto GetHepatitisBCompleto(int id)
        {
            _logger.LogInformation($"Executing repository HepatitisBCompleto to GetHepatitisBCompleto {id}");

            var model = new HepatitisBCompleto();
            model.IdGestanteControl = id;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    model.DiagnosticoGestante = GetDiagnosticoGestante(connection, id);
                    model.SeguimientoNinoExpuesto = GetSeguimientoNinoExpuesto(connection, id);
                    
                    return model;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private List<DiagnosticoGestanteHB> GetDiagnosticoGestante(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM HB_DiagnosticoGestante WHERE IdGestanteControl = @Id";
            var data = connection.Query<DiagnosticoGestanteHB>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"DiagnosticoGestanteHB with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                if (item.IdMomentoDiagnostico > 0)
                    item.MomentoDiagnostico = utilService.GetParametricaById(item.IdMomentoDiagnostico);
                item.TratamientoSeguimientoGestante = GetTratamientoSeguimientoGestante(connection, item.IdDiagnosticoGestante);
            }

            return data.ToList();
        }

        private List<TratamientoSeguimientoGestanteHB> GetTratamientoSeguimientoGestante(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM HB_TratamientoSeguimientoGestante WHERE IdDiagnosticoGestante = @Id";
            var data = connection.Query<TratamientoSeguimientoGestanteHB>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"TratamientoSeguimientoGestanteHB with IdDiagnosticoGestante {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.SituacionGestante = utilService.GetParametricaById(item.IdSituacionGestante);                
            }

            return data.ToList();
        }

        private List<SeguimientoNinoExpuestoHB> GetSeguimientoNinoExpuesto(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM HB_SeguimientoNinoExpuesto WHERE IdGestanteControl = @Id";
            var data = connection.Query<SeguimientoNinoExpuestoHB>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"SeguimientoNinoExpuestoHB with IdGestanteControl {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.CondicionRecienNacido = utilService.GetParametricaById(item.IdCondicionRecienNacido);
                item.TipoParto = utilService.GetParametricaById(item.IdTipoParto);
                item.NumeroProductosNacimiento = utilService.GetParametricaById(item.IdNumeroProductosNacimiento);
                item.Sexo = utilService.GetParametricaById(item.IdSexo);
                item.TipoRegimenSalud = utilService.GetParametricaById(item.IdTipoRegimenSalud);
                item.TipoDocumento = utilService.GetParametricaById(item.IdTipoDocumento);
                item.TiempoAplicacionVacuna = utilService.GetParametricaById(item.IdTiempoAplicacionVacuna);
                item.TiempoAplicacionInmonoglobulina = utilService.GetParametricaById(item.IdTiempoAplicacionInmonoglobulina);
                item.Vacunacion = GetVacunacion(connection, item.IdSeguimientoNinoExpuesto);
                item.ClasificacionNinoExpuesto = GetClasificacionNinoExpuesto(connection, item.IdSeguimientoNinoExpuesto);
            }

            return data.ToList();
        }

        private List<VacunacionHB> GetVacunacion(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM HB_Vacunacion WHERE IdSeguimientoNinoExpuesto = @Id";
            var data = connection.Query<VacunacionHB>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"VacunacionHB with IdSeguimientoNinoExpuesto {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.DosisVacuna = utilService.GetParametricaById(item.IdDosisVacuna);
            }

            return data.ToList();
        }

        private List<ClasificacionNinoExpuestoHB> GetClasificacionNinoExpuesto(SqlConnection connection, int id)
        {
            if (id < 0) return [];

            var utilService = new Util(_logger, _connectionString);
            string query = "SELECT * FROM HB_ClasificacionNinoExpuesto WHERE IdSeguimientoNinoExpuesto = @Id";
            var data = connection.Query<ClasificacionNinoExpuestoHB>(query, new { Id = id });

            if (data == null)
            {
                _logger.LogInformation($"ClasificacionNinoExpuestoHB with IdSeguimientoNinoExpuesto {id} not was found");
                return [];
            }

            foreach (var item in data)
            {
                item.ResultadoAntiHBsAg = utilService.GetParametricaById(item.IdResultadoAntiHBsAg);
                item.ResultadoAntiHBs = utilService.GetParametricaById(item.IdResultadoAntiHBs);
                item.CondicionFinal = utilService.GetParametricaById(item.IdCondicionFinal);
                item.ClasificacionFinal = utilService.GetParametricaById(item.IdClasificacionFinal);
            }

            return data.ToList();
        }
    }
}
