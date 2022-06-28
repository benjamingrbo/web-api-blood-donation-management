using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RWAAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RWAAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DonacijaController : ControllerBase
    {
        bazaContext db = new bazaContext();

        [HttpGet]

        public IActionResult prikaziSveDonacije()
        {
            List<VwDonacije> sveDonacije = db.VwDonacijes.OrderByDescending(x => x.Jmbg).ToList();
            return Ok(sveDonacije);
        }


        [HttpGet]
        public IActionResult donacijePoJMBG(string jmbg)
        {
            List<VwDonacije> donacije = db.VwDonacijes.OrderByDescending(x => x.Datum).Where(x => x.Jmbg.Equals(jmbg)).ToList();
            return Ok(donacije);
        }

        [HttpPost]
        public IActionResult unesiDonaciju([FromBody] Donacija podaci)
        {
            db.Add(podaci);// fino spakovat objekat na frontu
            db.SaveChanges();

            return Ok(podaci);
        }


    }
}