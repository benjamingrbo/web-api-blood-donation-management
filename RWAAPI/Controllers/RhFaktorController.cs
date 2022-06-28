using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RWAAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RWAAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RhFaktorController : ControllerBase
    {
        bazaContext db = new bazaContext();

        
        [HttpGet]
        public IActionResult prikaziSveRhFaktore()
        {
            List<RhFaktor> sviFaktori = db.RhFaktors.ToList();
            return Ok(sviFaktori);
        }
    }
}
