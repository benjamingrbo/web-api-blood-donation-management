using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class Osoba
    {
        public Osoba()
        {
            Donacijas = new HashSet<Donacija>();
            HistorijaBolestis = new HashSet<HistorijaBolesti>();
        }

        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojKnjizice { get; set; }
        public string Adresa { get; set; }
        public int OpcinaId { get; set; }
        public int KrvnaGrupaId { get; set; }
        public int FaktorId { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Napomena { get; set; }

        public virtual RhFaktor Faktor { get; set; }
        public virtual KrvnaGrupa KrvnaGrupa { get; set; }
        public virtual Opcina Opcina { get; set; }
        public virtual ICollection<Donacija> Donacijas { get; set; }
        public virtual ICollection<HistorijaBolesti> HistorijaBolestis { get; set; }
    }
}
