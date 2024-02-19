using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPSEtmiPlus.Helpers;
using OPSEtmiPlus.Models.DTOs;
using OPSEtmiPlus.Models.HepatitisB;
using OPSEtmiPlus.Repositories.HepatitisB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OPSEtmiPlus.Controllers.HepatitisB
{
    [Route("api/GestanteControl/Seguimiento/{idSeguimiento}/HepatitisB/[controller]")]
    [ApiController]
    public class VacunacionController : ControllerBase
    {
        public static void Initialize(IConfiguration iConfig)
        {
            CommonApiHelpers.configuration = iConfig;
        }

        // POST api/GestanteControl/Seguimiento/5/HepatitisB/<VacunacionController>
        //[Authorize]
        [HttpPost]
        public IActionResult Post(ILogger<VacunacionController> logger, int idSeguimiento, [FromBody] List<VacunacionHB> list)
        {
            logger.LogInformation("Executing Create Vacunacion");
            string connectionString = CommonApiHelpers.GetConnectionString();
            IVacunacionRepository repository = new VacunacionRepository(logger, connectionString);

            try
            {

                List<VacunacionHB> data = [];
                foreach (var item in list)
                {
                    var result = repository.CreateVacunacion(idSeguimiento, item);
                    data.Add(result);
                }

                var response = new ApiResponse<List<VacunacionHB>>(true, Messages.SuccessExecApi, data);
                return Ok(response);

                /*var data = repository.CreateVacunacion(idSeguimiento, model);
                var response = new ApiResponse<VacunacionHB>(true, Messages.SuccessExecApi, data);
                return Ok(response);*/
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>(false, Messages.ErrorExecApi, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
