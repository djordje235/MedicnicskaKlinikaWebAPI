using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacijentController : ControllerBase
    {
        [HttpPost]
        [Route("DodajPacijenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajPacijenta([FromBody] PacijentView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, long jmbgLekara)
        {
            try
            {
                DataProvider.dodajPacijenta(admin, emailovi, telefoni, jmbgLekara);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPacijenta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiPacijenta()
        {
            try
            {
                return new JsonResult(DataProvider.prikazPacijenta());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniPacijenta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniPacijenta([FromBody] PacijentView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, long jmbgLekara, int idKartona)
        {
            try
            {
                DataProvider.izmeniPacijenta(admin, emailovi, telefoni, jmbgLekara, idKartona);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiPacijenta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiPacijenta(int idKartona)
        {
            try
            {
                DataProvider.brisiPacijenta(idKartona);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
