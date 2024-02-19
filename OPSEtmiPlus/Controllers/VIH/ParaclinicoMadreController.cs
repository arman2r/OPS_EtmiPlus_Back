using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.VIH;
using OPSEtmiPlus.Repositories.VIH;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.VIH
{
    [Route("api/GestanteControl/Reporte1/{idReporte}/VIH/[controller]")]
    [ApiController]
    public class ParaclinicoMadreController : ControllerBase
    {        
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/Reporte1/5/VIH/<ParaclinicoMadreController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<ParaclinicoMadreController> logger, int idReporte, [FromBody] List<ParaclinicoMadre> list)
        {
            logger.LogInformation("Executing Create ParaclinicoMadre");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IParaclinicoMadreRepository repository = new ParaclinicoMadreRepository(logger, connectionString);

            try
            {
                List<ParaclinicoMadre> data = [];
                foreach (var item in list)
                {
                    var result = repository.CreateParaclinicoMadre(idReporte, item);
                    data.Add(result);
                }
                
                var response = new ApiResponse<List<ParaclinicoMadre>>(true, Messages.SuccessExecApi, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }

        // POST api/GestanteControl/Reporte1/VIH/<ParaclinicoMadreController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(ILogger<ParaclinicoMadreController> logger, int idParaclinico, [FromBody] ParaclinicoMadre model)
        {
            logger.LogInformation("Executing Update ParaclinicoMadre");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IParaclinicoMadreRepository repository = new ParaclinicoMadreRepository(logger, connectionString);

            try
            {
                var data = repository.UpdateParaclinicoMadre(idParaclinico, model);
                var response = new ApiResponse<ParaclinicoMadre>(true, Messages.SuccessExecApi, data);
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
