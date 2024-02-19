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
    [Route("api/GestanteControl/DiagnosticoMaterno/{idDiagnosticoMaterno}/Sifilis/[controller]")]
    [ApiController]
    public class TratamientoMaternoEstadioClinicoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/DiagnosticoMaterno/5/<TratamientoMaternoEstadioClinicoController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<TratamientoMaternoEstadioClinicoController> logger, int idDiagnosticoMaterno, [FromBody] TratamientoMaternoEstadioClinico model)
        {
            logger.LogInformation("Executing Create TratamientoMaternoEstadioClinico");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ITratamientoMaternoEstadioClinicoRepository repository = new TratamientoMaternoEstadioClinicoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateTratamientoMaternoEstadioClinico(idDiagnosticoMaterno, model);
                var response = new ApiResponse<TratamientoMaternoEstadioClinico>(true, Messages.SuccessExecApi, data);
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
