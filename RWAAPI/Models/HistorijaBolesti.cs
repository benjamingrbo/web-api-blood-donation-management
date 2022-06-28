using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class HistorijaBolesti
    {
        public int DijagnozaId { get; set; }
        public string Jmbg { get; set; }
        public string Dijagnoza { get; set; }
        public DateTime Datum { get; set; }

        public virtual Osoba JmbgNavigation { get; set; }
    }
}
