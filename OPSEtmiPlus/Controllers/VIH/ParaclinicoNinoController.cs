using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Repositories.VIH;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.VIH
{
    [Route("api/GestanteControl/Reporte5/{idReporte}/VIH/[controller]")]
    [ApiController]
    public class ParaclinicoNinoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/Reporte5/5/VIH/<ParaclinicoNinoController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<ParaclinicoNinoController> logger, int idReporte, [FromBody] List<ParaclinicoNino> list)
        {
            logger.LogInformation("Executing Create ParaclinicoNino");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IParaclinicoNinoRepository repository = new ParaclinicoNinoRepository(logger, connectionString);

            try
            {
                List<ParaclinicoNino> data = [];
                foreach (var item in list)
                {
                    var result = repository.CreateParaclinicoNino(idReporte, item);
                    data.Add(result);
                }

                var response = new ApiResponse<List<ParaclinicoNino>>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST api/GestanteControl/Reporte5/VIH/<ParaclinicoNinoController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(ILogger<ParaclinicoNinoController> logger, int idParaclinico, [FromBody] ParaclinicoNino model)
        {
            logger.LogInformation("Executing Update ParaclinicoNino");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IParaclinicoNinoRepository repository = new ParaclinicoNinoRepository(logger, connectionString);

            try
            {
                var data = repository.UpdateParaclinicoNino(idParaclinico, model);
                var response = new ApiResponse<ParaclinicoNino>(true, Messages.SuccessExecApi, data);
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
