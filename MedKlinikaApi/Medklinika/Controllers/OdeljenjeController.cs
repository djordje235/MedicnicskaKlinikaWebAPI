using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OdeljenjeController : ControllerBase
    {
        [HttpPost]
        [Route("DodajOdeljenje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajOdeljenje([FromBody] OdeljenjeView admin, long jmbgGlavnogLekara, [FromQuery] List<string> adresa)
        {
            try
            {
                DataProvider.dodajOdeljenje(admin, jmbgGlavnogLekara, adresa, false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiOdeljenje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiOdeljenje()
        {
            try
            {
                return new JsonResult(DataProvider.prikazOdeljenja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniOdeljenje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniOdeljenje([FromBody] OdeljenjeView admin, long jmbgGlavnogLekara, [FromQuery]List<string> adresa)
        {
            try
            {
                DataProvider.dodajOdeljenje(admin, jmbgGlavnogLekara, adresa, true);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiOdeljenje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiOdeljenje(string naziv)
        {
            try
            {
                DataProvider.brisiOdeljenje(naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
