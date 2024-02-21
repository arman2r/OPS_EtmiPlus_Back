using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.Chagas;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Repositories.Chagas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.Chagas
{
    [Route("api/GestanteControl/Algoritmo/{idAlgoritmo}/Chagas/[controller]")]
    [ApiController]
    public class TratamientoMaternoController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/Algoritmo/5/Chagas/<TratamientoMaternoController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<TratamientoMaternoController> logger, int idAlgoritmo, [FromBody] TratamientoMaternoChagas model)
        {
            logger.LogInformation("Executing Create TratamientoMaterno");
            string connectionString = CommonApiHelpers.GetConnectionString();
            ITratamientoMaternoRepository repository = new TratamientoMaternoRepository(logger, connectionString);

            try
            {
                var data = repository.CreateTratamientoMaterno(idAlgoritmo, model);
                var response = new ApiResponse<TratamientoMaternoChagas>(true, Messages.SuccessExecApi, data);
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
