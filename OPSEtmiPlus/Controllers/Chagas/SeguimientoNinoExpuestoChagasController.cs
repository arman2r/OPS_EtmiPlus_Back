using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Repositories.Chagas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Chagas
{
    [Route("api/GestanteControl/Diagnostico/{idDiagnostico}/Chagas/[controller]")]
    [ApiController]
    public class SeguimientoNinoExpuestoChagasController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/Diagnostico/5/Chagas/<SeguimientoNinoExpuestoChagasController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<SeguimientoNinoExpuestoChagasController> logger, int idDiagnostico, [FromBody] SeguimientoNinoExpuestoChagas model)
        {
            logger.LogInformation("Executing Create ParaclinicoMadre");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ISeguimientoNinoExpuestoChagasRepository repository = new SeguimientoNinoExpuestoChagasRepository(logger, connectionString);

            try
            {
                var data = repository.CreateSeguimientoNinoExpuestoChagas(idDiagnostico, model);
                var response = new ApiResponse<SeguimientoNinoExpuestoChagas>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
