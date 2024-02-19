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
    [Route("api/GestanteControl/DiagnosticoIntervencionNino/{idDiagnosticoIntervencionNino}/Sifilis/[controller]")]
    [ApiController]
    public class SeguimientoNinoPrimerAnioController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/DiagnosticoIntervencionNino/5/Sifilis/<SeguimientoNinoDurantePrimerAnioVidaController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<SeguimientoNinoPrimerAnioController> logger, int idDiagnosticoIntervencionNino, [FromBody] SeguimientoNinoPrimerAnio model)
        {
            logger.LogInformation("Executing Create SeguimientoNinoDurantePrimerAnioVida");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ISeguimientoNinoPrimerAnioRepository repository = new SeguimientoNinoPrimerAnioRepository(logger, connectionString);

            try
            {
                var data = repository.CreateSeguimientoNinoPrimerAnio(idDiagnosticoIntervencionNino, model);
                var response = new ApiResponse<SeguimientoNinoPrimerAnio>(true, Messages.SuccessExecApi, data);
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
