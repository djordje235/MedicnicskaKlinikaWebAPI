using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerminController : ControllerBase
    {
        [HttpPost]
        [Route("DodajTermin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajTermin([FromBody] TerminView admin, int idKartona, long jmbgLekara, string nazivOdeljenja)
        {
            try
            {
                DataProvider.dodajTermin(admin, idKartona, jmbgLekara, nazivOdeljenja, false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiTermin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiTermin()
        {
            try
            {
                return new JsonResult(DataProvider.prikazTermina());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniTermin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniTermin([FromBody] TerminView admin, int idKartona, long jmbgLekara, string nazivOdeljenja)
        {
            try
            {
                DataProvider.dodajTermin(admin, idKartona, jmbgLekara, nazivOdeljenja, true);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiTermin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiTermin(int id)
        {
            try
            {
                DataProvider.brisiTermin(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
