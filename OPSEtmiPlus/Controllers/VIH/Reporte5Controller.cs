using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Repositories.VIH;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.VIH
{
    [Route("api/GestanteControl/{idGestanteControl}/VIH/[controller]")]
    [ApiController]
    public class Reporte5Controller : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/VIH/<Reporte5Controller>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<Reporte5Controller> logger, int idGestanteControl, [FromBody] Reporte5 model)
        {
            logger.LogInformation("Executing Create Reporte5");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporte5Repository repository = new Reporte5Repository(logger, connectionString);

            try
            {
                var data = repository.CreateReporte5(idGestanteControl, model);
                var response = new ApiResponse<Reporte5>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST api/GestanteControl/VIH/<Reporte1Controller>/5
        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(ILogger<Reporte5Controller> logger, int idReporte, [FromBody] Reporte5 model)
        {
            logger.LogInformation("Executing Update Reporte5");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporte5Repository repository = new Reporte5Repository(logger, connectionString);

            try
            {
                var data = repository.UpdateReporte5(idReporte, model);
                var response = new ApiResponse<Reporte5>(true, Messages.SuccessExecApi, data);
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
