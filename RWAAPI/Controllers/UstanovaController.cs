using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RWAAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RWAAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UstanovaController : ControllerBase
    {
        bazaContext db = new bazaContext();


        // GET: api/<OsobeController>
        [HttpGet]

        public IActionResult prikaziSveUstanove()
        {
            List<VwUstanova> sveUstanove = db.VwUstanovas.ToList();
            return Ok(sveUstanove);
        }


        // POST api/<OsobeController>
        [HttpPost]
        public IActionResult unesiUstanova([FromBody] Ustanova podaci)
        {
            db.Add(podaci);// fino spakovat objekat na frontu
            db.SaveChanges();

            return Ok(podaci);
        }

        [HttpPut("{id}")]
        public IActionResult izmijeni(int id, [FromBody] Ustanova podaci)
        {
            Ustanova ustanova = db.Ustanovas.Where(x => x.UstanovaId.Equals(id)).FirstOrDefault();
            if (ustanova != null)
            {
                ustanova.NazivUstanove = (podaci.NazivUstanove != null) ? podaci.NazivUstanove : ustanova.NazivUstanove;
                ustanova.OpcinaId = (podaci.OpcinaId != null) ? podaci.OpcinaId : ustanova.OpcinaId;


                db.SaveChanges();
            }
            else
            {
                return NotFound($"Osoba sa id {podaci.UstanovaId} nije pronadjena");
            }
            return Ok(ustanova);

        }

        [HttpDelete("{id}")]
        public IActionResult obrisiUstanovu(int id)
        {
            Ustanova ustanova = db.Ustanovas.Where(a => a.UstanovaId == id).FirstOrDefault();
            if (ustanova == null)
            {
                return NotFound($"Podatak sa ID = {id} nije pronadjen");
            }
            else
            {
                db.Remove(ustanova);
                db.SaveChanges();
            }
            return Ok("Obrisano");
        }

    }
}