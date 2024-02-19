using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.Sifilis;
using OPSEtmiPlus.Repositories.Sifilis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Sifilis
{
    [Route("api/GestanteControl/Sifilis/[controller]/{id}")]
    [ApiController]
    public class AplicacionPenicilinaBenzatinicaController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/Gestante/5/Sifilis/<AplicacionPenicilinaBenzatinicaController>/Tratamiento
        [Authorize]
        [HttpPost("Tratamiento")]
        public IActionResult PostTratamiento(ILogger<AplicacionPenicilinaBenzatinicaController> logger, int id, [FromBody] AplicacionPenicilinaBenzatinica model)
        {
            logger.LogInformation("Executing Create SeguimientoContactoSexual Tratamiento");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IAplicacionPenicilinaBenzatinicaRepository repository = new AplicacionPenicilinaBenzatinicaRepository(logger, connectionString);
        
            try
            {
                var data = repository.CreateAplicacionPenicilinaBenzatinica(id, null, null, model);
                var response = new ApiResponse<AplicacionPenicilinaBenzatinica>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST api/Gestante/5/Sifilis/<AplicacionPenicilinaBenzatinicaController>/Retratamiento
        [Authorize]
        [HttpPost("Retratamiento")]
        public IActionResult PostRetratamiento(ILogger<AplicacionPenicilinaBenzatinicaController> logger, int id, [FromBody] AplicacionPenicilinaBenzatinica model)
        {
            logger.LogInformation("Executing Create SeguimientoContactoSexual Retratamiento");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IAplicacionPenicilinaBenzatinicaRepository repository = new AplicacionPenicilinaBenzatinicaRepository(logger, connectionString);
  
            try
            {
                var data = repository.CreateAplicacionPenicilinaBenzatinica(null, id, null, model);
                var response = new ApiResponse<AplicacionPenicilinaBenzatinica>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST api/Gestante/5/Sifilis/<AplicacionPenicilinaBenzatinicaController>/Seguimiento
        [Authorize]
        [HttpPost("Seguimiento")]
        public IActionResult Post(ILogger<AplicacionPenicilinaBenzatinicaController> logger, int id, [FromBody] AplicacionPenicilinaBenzatinica model)
        {
            logger.LogInformation("Executing Create SeguimientoContactoSexual Seguimiento");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IAplicacionPenicilinaBenzatinicaRepository repository = new AplicacionPenicilinaBenzatinicaRepository(logger, connectionString);

            try
            {
                var data = repository.CreateAplicacionPenicilinaBenzatinica(null, null, id, model);
                var response = new ApiResponse<AplicacionPenicilinaBenzatinica>(true, Messages.SuccessExecApi, data);
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
