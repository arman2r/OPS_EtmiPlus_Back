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
    public class Reporte2Controller : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/VIH/<Reporte2Controller>
        //[Authorize]
        [HttpPost]        
        public IActionResult Post(ILogger<Reporte2Controller> logger, int idGestanteControl, [FromBody] Reporte2 model)
        {
            logger.LogInformation("Executing Create Reporte2");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporte2Repository repository = new Reporte2Repository(logger, connectionString);

            try
            {
                var data = repository.CreateReporte2(idGestanteControl, model);
                var response = new ApiResponse<Reporte2>(true, Messages.SuccessExecApi, data);
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
        public IActionResult Put(ILogger<Reporte2Controller> logger, int idReporte, [FromBody] Reporte2 model)
        {
            logger.LogInformation("Executing Update Reporte1");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporte2Repository repository = new Reporte2Repository(logger, connectionString);

            try
            {
                var data = repository.UpdateReporte2(idReporte, model);
                var response = new ApiResponse<Reporte2>(true, Messages.SuccessExecApi, data);
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
