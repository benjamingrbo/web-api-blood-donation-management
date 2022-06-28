using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class Grad
    {
        public Grad()
        {
            Opcinas = new HashSet<Opcina>();
        }

        public int GradId { get; set; }
        public string NazivGrada { get; set; }

        public virtual ICollection<Opcina> Opcinas { get; set; }
    }
}
