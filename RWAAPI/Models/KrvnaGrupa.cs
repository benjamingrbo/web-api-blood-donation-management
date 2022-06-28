using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class KrvnaGrupa
    {
        public KrvnaGrupa()
        {
            Osobas = new HashSet<Osoba>();
        }

        public int KrvnaGrupaId { get; set; }
        public string KrvnaGrupa1 { get; set; }

        public virtual ICollection<Osoba> Osobas { get; set; }
    }
}
