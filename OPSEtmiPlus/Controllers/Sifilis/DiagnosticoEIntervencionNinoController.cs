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
    [Route("api/GestanteControl/{idGestante}/Sifilis/[controller]")]
    [ApiController]
    public class DiagnosticoEIntervencionNinoController : ControllerBase
    {        
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/Sifilis/<DiagnosticoEIntervencionNinoController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<TratamientoSeguimientoGestanteController> logger, int idGestante, [FromBody] DiagnosticoEIntervencionNino model)
        {
            logger.LogInformation("Executing Create TratamientoSeguimientoGestante");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IDiagnosticoEIntervencionNinoRepository repository = new DiagnosticoEIntervencionNinoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateDiagnosticoEIntervencionNino(idGestante, model);
                var response = new ApiResponse<DiagnosticoEIntervencionNino>(true, Messages.SuccessExecApi, data);
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
