using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RWAAPI.Models;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RWAAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OsobeController : ControllerBase
    {
        bazaContext db = new bazaContext();

        // GET: api/<OsobeController>
        [HttpGet]
        public IActionResult prikaziSveOsobe()
        {
            List<VwSveOsobe> sveOsobe = db.VwSveOsobes.ToList();
            return Ok(sveOsobe);
        }


        [HttpGet]
        public IActionResult osobaPoJMBG(string jmbg)
        {
            List<VwSveOsobe> osoba = db.VwSveOsobes.Where(x => x.Jmbg.Equals(jmbg)).ToList();
            return Ok(osoba);
        }


        [EnableCors]
        // POST api/<OsobeController>
        [HttpPost]
        public IActionResult unesiDonora([FromBody] Osoba podaci)
        {
            db.Add(podaci); // fino spakovat objekat na frontu
            db.SaveChanges();
            return Ok(podaci);
        }


        // PUT api/<OsobeController>/5
        [HttpPut("{jmbg}")]
        public IActionResult izmijeni(string jmbg, [FromBody] Osoba podaci)
        {
            Osoba osoba = db.Osobas.Where(x => x.Jmbg.Equals(jmbg)).FirstOrDefault();
            if (osoba != null)
            {
                osoba.Ime = (podaci.Ime != null) ? podaci.Ime : osoba.Ime;
                osoba.Prezime = (podaci.Prezime != null) ? podaci.Prezime : osoba.Prezime;
                osoba.BrojKnjizice = (podaci.BrojKnjizice != null) ? podaci.BrojKnjizice : osoba.BrojKnjizice;
                osoba.Adresa = (podaci.Adresa != null) ? podaci.Adresa : osoba.Adresa;
                osoba.Email = (podaci.Email != null) ? podaci.Email : osoba.Email;
                osoba.Napomena = (podaci.Napomena != null) ? podaci.Napomena : osoba.Napomena;
                osoba.OpcinaId = (podaci.OpcinaId != null) ? podaci.OpcinaId : osoba.OpcinaId;
                osoba.Telefon = (podaci.Telefon != null) ? podaci.Telefon : osoba.Telefon;
                osoba.KrvnaGrupaId = (podaci.KrvnaGrupaId != null) ? podaci.KrvnaGrupaId : osoba.KrvnaGrupaId;
                osoba.FaktorId = (podaci.FaktorId != null) ? podaci.FaktorId : osoba.FaktorId;

                db.SaveChanges();
            }
            else
            {
                return NotFound($"Osoba sa id {podaci.Jmbg} nije pronadjena");
            }
            return Ok(osoba);
        }

        [HttpDelete("{jmbg}")]
        public IActionResult obrisiPodatak(string jmbg)
        {
            Osoba osoba = db.Osobas.Where(a => a.Jmbg == jmbg).FirstOrDefault();


            if (osoba == null)
            {
                return NotFound($"Podatak sa ID = {jmbg} nije pronadjen");
            }
            else
            {
                try
                {
                    db.Remove(osoba);
                    db.SaveChanges();
                }
                catch
                {
                    return BadRequest("Osoba postoji u bazi donacija, te brisanje nije moguće !");
                }
            }
            return Ok("Obrisano");
        }
    }
}