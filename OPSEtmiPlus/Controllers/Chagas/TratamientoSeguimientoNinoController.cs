using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Repositories.Chagas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Chagas
{
    [Route("api/GestanteControl/Seguimiento/{idSeguimiento}/Chagas/[controller]")]
    [ApiController]
    public class TratamientoSeguimientoNinoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/Seguimiento/5/Chagas/<TratamientoSeguimientoNinoController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<TratamientoSeguimientoNinoController> logger, int idSeguimiento, [FromBody] TratamientoSeguimientoNinoChagas model)
        {
            logger.LogInformation("Executing Create TratamientoSeguimientoNino");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ITratamientoSeguimientoNinoRepository repository = new TratamientoSeguimientoNinoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateTratamientoSeguimientoNino(idSeguimiento, model);
                var response = new ApiResponse<TratamientoSeguimientoNinoChagas>(true, Messages.SuccessExecApi, data);
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
