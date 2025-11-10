using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacanjeController : ControllerBase
    {
        [HttpPost]
        [Route("DodajPlacanje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajPlacanje([FromBody] PlacanjeView p, int idRFZO, int idPrivatnogOsiguranja, int idRacuna)
        {
            try
            {
                DataProvider.dodajPlacanje(p, false, idRFZO, idPrivatnogOsiguranja, idRacuna);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPlacanje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiPlacanje()
        {
            try
            {
                return new JsonResult(DataProvider.prikazPlacanja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniPlacanje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniPlacanje([FromBody] PlacanjeView p, int idRFZO, int idPrivatnogOsiguranja, int idRacuna)
        {
            try
            {
                DataProvider.dodajPlacanje(p, true, idRFZO, idPrivatnogOsiguranja, idRacuna);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiPlacanje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiPlacanje(int id)
        {
            try
            {
                DataProvider.brisiPlacanje(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
