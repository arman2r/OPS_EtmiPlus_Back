using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Controllers.VIH;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Repositories.HepatitisB;
using OPSEtmiPlus.Repositories.VIH;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.HepatitisB
{
    [Route("api/GestanteControl/{idGestante}/HepatitisB/[controller]")]
    [ApiController]
    public class SeguimientoNinoExpuestoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/HepatitisB/<SeguimientoNinoExpuestoController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<SeguimientoNinoExpuestoController> logger, int idGestante, [FromBody] SeguimientoNinoExpuestoHB model)
        {
            logger.LogInformation("Executing Create SeguimientoNinoExpuesto");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ISeguimientoNinoExpuestoRepository repository = new SeguimientoNinoExpuestoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateSeguimientoNinoExpuesto(idGestante, model);
                var response = new ApiResponse<SeguimientoNinoExpuestoHB>(true, Messages.SuccessExecApi, data);
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
