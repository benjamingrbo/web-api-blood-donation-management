using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class VwHistorija
    {
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojKnjizice { get; set; }
        public DateTime Datum { get; set; }
        public string Dijagnoza { get; set; }
    }
}
