using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrivatnoOsiguranjeController : ControllerBase
    {
        [HttpPost]
        [Route("DodajPrivatnoOsiguranje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajPrivatnoOsiguranje([FromBody] PrivatnoOsiguranjeView admin, int idKartona)
        {
            try
            {
                DataProvider.dodajPrivatnoOsiguranje(admin, false, idKartona);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPrivatnoOsiguranje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiPrivatnoOsiguranje()
        {
            try
            {
                return new JsonResult(DataProvider.prikazPrivatnogOsiguranja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniPrivatnoOsiguranje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniPrivatnoOsiguranje([FromBody] PrivatnoOsiguranjeView admin, int idKartona)
        {
            try
            {
                DataProvider.dodajPrivatnoOsiguranje(admin, true, idKartona);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiPrivatnoOsiguranje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiPrivatnoOsiguranje(int id)
        {
            try
            {
                DataProvider.brisiPrivatnoOsiguranje(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
