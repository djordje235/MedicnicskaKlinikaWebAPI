using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using DatabaseAccess.Entiteti;
namespace Medklinika.Controllers
{        
    [ApiController]
    [Route("[controller]")]
    public class LaboratorijskaAnalizaController : ControllerBase
    {
        [HttpPost]
        [Route("DodajLaboratorijskuAnalizu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajLaboratorijskuAnalizu([FromBody] LaboratorijskaAnalizaView admin, int idKartona, long jmbgLaboranta, int idPregleda)
        {
            try
            {
                DataProvider.dodajLaboratorijskuAnalizu(admin,false, idKartona, jmbgLaboranta, idPregleda);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiLaboratorijskuAnalizu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PreuzmiLaboratorijskuAnalizu()
        {
            try
            {
                return new JsonResult(DataProvider.prikazLaboratorijskeAnalize());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("izmeniLaboratorijskuAnalizu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult izmeniLaboratorijskuAnalizu([FromBody] LaboratorijskaAnalizaView admin, int idKartona, long jmbgLaboranta, int idPregleda)
        {
            try
            {
                DataProvider.dodajLaboratorijskuAnalizu(admin, true, idKartona, jmbgLaboranta, idPregleda);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("obrisiLaboratorijskuAnalizu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult obrisiLaboratorijskuAnalizu(int id)
        {
            try
            {
                DataProvider.brisiLaboratorijskuAnalizu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
