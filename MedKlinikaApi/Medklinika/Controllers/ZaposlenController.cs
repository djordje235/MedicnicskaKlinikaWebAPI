using DatabaseAccess;
using DatabaseAccess.DTOs;
using DatabaseAccess.Entiteti;
using Microsoft.AspNetCore.Mvc;

namespace Medklinika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZaposlenController : ControllerBase
    {
        //Administrativno Osoblje
        [HttpPost]
        [Route("DodajAdministrativnoOsoblje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajAdministativnoOsoblje([FromBody] AdministrativnoOsobljeView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja, string lokacija)
        {
            try
            {
                DataProvider.dodajAdministrativnoOsoblje(admin, emailovi, telefoni, odeljenja, lokacija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiAdministrativnoOsoblje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiAdministrativnoOsoblje()
        {
            try
            {
                return new JsonResult(DataProvider.prikazOsoblja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniAdministrativnoOsoblje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniAdministrativnoOsoblje([FromBody] AdministrativnoOsobljeView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja, string lokacija)
        {
            try
            {
                DataProvider.izmeniAdministrativnoOsoblje(admin, emailovi, telefoni, odeljenja, lokacija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiAdministrativnoOsoblje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiAdministrativnoOsoblje(long jmbg)
        {
            try
            {
                DataProvider.brisiAdmina(jmbg);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        //Medicinska Sestra
        [HttpPost]
        [Route("DodajMedicinskuSestru")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajMedicinskuSestru([FromBody] MedicinskaSestraView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja, string lokacija)
        {
            try
            {
                DataProvider.dodajMedicinskuSestru(admin, emailovi, telefoni, odeljenja, lokacija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiMedicinskuSestru")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiMedicinskuSestru()
        {
            try
            {
                return new JsonResult(DataProvider.prikaziMedicinskuSestru());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniMedicinskuSestru")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniMedicinskuSestru([FromBody] MedicinskaSestraView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja, string lokacija)
        {
            try
            {
                DataProvider.izmeniMedicinskuSestru(admin, emailovi, telefoni, odeljenja, lokacija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiMedicinskuSestru")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiMedicinskuSestru(long jmbg)
        {
            try
            {
                DataProvider.brisiMedicinskuSestru(jmbg);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //Laborant
        [HttpPost]
        [Route("DodajLaboranta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajLaboranta([FromBody] LaborantView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja, string lokacija)
        {
            try
            {
                DataProvider.dodajLaboranta(admin, emailovi, telefoni, odeljenja, lokacija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiLaboranta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiLaboranta()
        {
            try
            {
                return new JsonResult(DataProvider.prikaziLaboranta());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniLaboranta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniLaboranta([FromBody] LaborantView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja, string lokacija)
        {
            try
            {
                DataProvider.izmeniLaboranta(admin, emailovi, telefoni, odeljenja, lokacija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiLaboranta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiLaboranta(long jmbg)
        {
            try
            {
                DataProvider.brisiLaboranta(jmbg);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //Lekar
        [HttpPost]
        [Route("DodajLekara")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajLekara([FromBody] LekarView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja, string lokacija)
        {
            try
            {
                DataProvider.dodajLekara(admin, emailovi, telefoni, odeljenja, lokacija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiLekara")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiLekara()
        {
            try
            {
                return new JsonResult(DataProvider.prikaziLekara());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniLekara")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniLekara([FromBody] LekarView admin, [FromQuery] List<string> emailovi, [FromQuery] List<string> telefoni, [FromQuery] List<string> odeljenja, string lokacija)
        {
            try
            {
                DataProvider.izmeniLekara(admin, emailovi, telefoni, odeljenja, lokacija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiLekara")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiLekara(long jmbg)
        {
            try
            {
                DataProvider.brisiLekara(jmbg);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }

}
