using System;
using System.Collections.Generic;

#nullable disable

namespace RWAAPI.Models
{
    public partial class VwDonacije
    {
        public int DonacijaId { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojKnjizice { get; set; }
        public string KrvnaGrupa { get; set; }
        public string Faktor { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        public string NazivUstanove { get; set; }
        public string NazivOpcine { get; set; }
    }
}
