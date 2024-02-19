using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Repositories.HepatitisB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.HepatitisB
{
    [Route("api/GestanteControl/{idGestante}/HepatitisB/[controller]")]
    [ApiController]
    public class TratamientoSeguimientoGestanteController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/HepatitisB/<TratamientoSeguimientoGestanteController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<TratamientoSeguimientoGestanteController> logger, int idGestante, [FromBody] TratamientoSeguimientoGestanteHB model)
        {
            logger.LogInformation("Executing Create TratamientoSeguimientoGestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ITratamientoSeguimientoGestanteRepository repository = new TratamientoSeguimientoGestanteRepository(logger, connectionString);

            try
            {
                var data = repository.CreateTratamientoSeguimientoGestante(idGestante, model);
                var response = new ApiResponse<TratamientoSeguimientoGestanteHB>(true, Messages.SuccessExecApi, data);
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
