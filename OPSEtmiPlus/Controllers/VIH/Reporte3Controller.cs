using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Repositories.VIH;
using OPSEtmiPlus.Models.VIH;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.VIH
{
    [Route("api/GestanteControl/{idGestanteControl}/VIH/[controller]")]
    [ApiController]
    public class Reporte3Controller : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/VIH/<Reporte3Controller>
        //[Authorize]
        [HttpPost]        
        public IActionResult Post(ILogger<Reporte3Controller> logger, int idGestanteControl, [FromBody] Reporte3 model)
        {
            logger.LogInformation("Executing Create Reporte3");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporte3Repository repository = new Reporte3Repository(logger, connectionString);

            try
            {
                var data = repository.CreateReporte3(idGestanteControl, model);
                var response = new ApiResponse<Reporte3>(true, Messages.SuccessExecApi, data);
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
        public IActionResult Put(ILogger<Reporte3Controller> logger, int idReporte, [FromBody] Reporte3 model)
        {
            logger.LogInformation("Executing Update Reporte3");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporte3Repository repository = new Reporte3Repository(logger, connectionString);

            try
            {
                var data = repository.UpdateReporte3(idReporte, model);
                var response = new ApiResponse<Reporte3>(true, Messages.SuccessExecApi, data);
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
