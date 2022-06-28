using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class Opcina
    {
        public Opcina()
        {
            Osobas = new HashSet<Osoba>();
            Ustanovas = new HashSet<Ustanova>();
        }

        public int OpcinaId { get; set; }
        public string NazivOpcine { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Osoba> Osobas { get; set; }
        public virtual ICollection<Ustanova> Ustanovas { get; set; }
    }
}
