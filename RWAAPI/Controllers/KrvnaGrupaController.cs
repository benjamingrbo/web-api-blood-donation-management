using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RWAAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RWAAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KrvnaGrupaController : ControllerBase
    {
        bazaContext db = new bazaContext();

        // GET: api/<OpcinaController>
        [HttpGet]
        public IActionResult prikaziSveKrvneGrupe()
        {
            List<KrvnaGrupa> sveKrvneGrupe = db.KrvnaGrupas.ToList();
            return Ok(sveKrvneGrupe);
        }

    }
}
