using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class RhFaktor
    {
        public RhFaktor()
        {
            Osobas = new HashSet<Osoba>();
        }

        public int FaktorId { get; set; }
        public string Faktor { get; set; }

        public virtual ICollection<Osoba> Osobas { get; set; }
    }
}
