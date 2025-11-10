using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PregledController : ControllerBase
    {
        [HttpPost]
        [Route("DodajPregled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajPregled([FromBody] PregledView admin,  long jmbgLekara, int idKartona,int idTermina, string NazivOdeljenja,int idPrethodnogPregleda)
        {
            try
            {
                DataProvider.dodajPregled(admin, false, idKartona, jmbgLekara,idTermina,NazivOdeljenja, idPrethodnogPregleda);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPregled")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiPregled()
        {
            try
            {
                return new JsonResult(DataProvider.prikazPregleda());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniPregled")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniPregled([FromBody] PregledView admin, long jmbgLekara, int idKartona, int idTermina, string NazivOdeljenja, int idPrethodnogPregleda)
        {
            try
            {
                DataProvider.dodajPregled(admin, true, idKartona, jmbgLekara, idTermina, NazivOdeljenja, idPrethodnogPregleda);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiPregled")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiPregled(int id)
        {
            try
            {
                DataProvider.brisiPregled(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
