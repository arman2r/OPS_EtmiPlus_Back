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
    public class Reporte1Controller : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/5/VIH/<Reporte1Controller>
        //[Authorize]
        [HttpPost]        
        public IActionResult Post(ILogger<Reporte1Controller> logger, int idGestanteControl, [FromBody] Reporte1 model)
        {
            logger.LogInformation("Executing Create Reporte1");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporte1Repository repository = new Reporte1Repository(logger, connectionString);

            try
            {
                var data = repository.CreateReporte1(idGestanteControl, model);
                var response = new ApiResponse<Reporte1>(true, Messages.SuccessExecApi, data);
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
        public IActionResult Put(ILogger<Reporte1Controller> logger, int idReporte, [FromBody] Reporte1 model)
        {
            logger.LogInformation("Executing Update Reporte1");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IReporte1Repository repository = new Reporte1Repository(logger, connectionString);

            try
            {
                var data = repository.UpdateReporte1(idReporte, model);
                var response = new ApiResponse<Reporte1>(true, Messages.SuccessExecApi, data);
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
