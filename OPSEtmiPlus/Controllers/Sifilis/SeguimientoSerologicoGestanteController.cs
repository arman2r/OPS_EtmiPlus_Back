using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Controllers.HepatitisB;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Repositories.HepatitisB;
using OPSEtmiPlus.Repositories.Sifilis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Sifilis
{
    [Route("api/GestanteControl/TratamientoMaternoEstadioClinico/{idTratamientoMaternoEstadioClinico}/Sifilis/[controller]")]
    [ApiController]
    public class SeguimientoSerologicoGestanteController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/TratamientoMaternoEstadioClinico/5/Sifilis/<SeguimientoSerologicoGestanteController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<SeguimientoSerologicoGestanteController> logger, int idTratamientoMaternoEstadioClinico, [FromBody] SeguimientoSerologicoGestante model)
        {
            logger.LogInformation("Executing Create SeguimientoSerologicoGestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ISeguimientoSerologicoGestanteRepository repository = new SeguimientoSerologicoGestanteRepository(logger, connectionString);

            try
            {
                var data = repository.CreateSeguimientoSerologicoGestante(idTratamientoMaternoEstadioClinico, model);
                var response = new ApiResponse<SeguimientoSerologicoGestante>(true, Messages.SuccessExecApi, data);
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
