using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZaposlenController : ControllerBase
    {
        [HttpPost]
        [Route("DodajAdministrativnoOsoblje/{lokacija}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajAdministativnoOsoblje([FromBody] AdministrativnoOsobljeView admin,[FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja,string lokacija)
        {
            try
            {
                DataProvider.dodajAdministrativnoOsoblje(admin,emailovi,telefoni,odeljenja, lokacija);
                return Ok();
            }
            catch(Exception ex) {
            return BadRequest(ex.ToString());
            }
        }
    }
}
