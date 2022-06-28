using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class Ustanova
    {
        public Ustanova()
        {
            Donacijas = new HashSet<Donacija>();
        }

        public int UstanovaId { get; set; }
        public string NazivUstanove { get; set; }
        public int OpcinaId { get; set; }

        public virtual Opcina Opcina { get; set; }
        public virtual ICollection<Donacija> Donacijas { get; set; }
    }
}
