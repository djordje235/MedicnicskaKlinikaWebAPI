using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RFZOController : ControllerBase
    {
        [HttpPost]
        [Route("DodajRFZO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajRFZO([FromBody] RFZOView admin, int idKartona)
        {
            try
            {
                DataProvider.dodajRFZO(admin, false, idKartona);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiRFZO")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiRFZO()
        {
            try
            {
                return new JsonResult(DataProvider.prikazRFZO());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniRFZO")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniRFZO([FromBody] RFZOView admin, int idKartona)
        {
            try
            {
                DataProvider.dodajRFZO(admin, true, idKartona);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiRFZO")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiRFZO(int id)
        {
            try
            {
                DataProvider.brisiRFZO(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
