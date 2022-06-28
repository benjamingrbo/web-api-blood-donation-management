using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class Donacija
    {
        public int DonacijaId { get; set; }
        public string Jmbg { get; set; }
        public int UstanovaId { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }

        public virtual Osoba JmbgNavigation { get; set; }
        public virtual Ustanova Ustanova { get; set; }
    }
}
