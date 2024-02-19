using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Repositories.HepatitisB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.HepatitisB
{
    [Route("api/Gestante/{idGestante}/HepatitisB/[controller]")]
    [ApiController]
    public class ClasificacionNinoExpuestoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/Gestante/5/HepatitisB/<ClasificacionNinoExpuestoController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<ClasificacionNinoExpuestoController> logger, int idGestante, [FromBody] ClasificacionNinoExpuestoHB model)
        {
            logger.LogInformation("Executing Create Reporte1");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IClasificacionNinoExpuestoRepository repository = new ClasificacionNinoExpuestoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateClasificacionNinoExpuesto(idGestante, model);
                var response = new ApiResponse<ClasificacionNinoExpuestoHB>(true, Messages.SuccessExecApi, data);
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
