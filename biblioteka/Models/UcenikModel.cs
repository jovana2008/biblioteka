using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Ucenik")]
    public class UcenikModel

    {
        [Key]
        public int UcenikID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public int? GodinaRodjenja { get; set; }

        public int? BrojUDnevniku { get; set; }

        public string Razred { get; set; }

        public string Odeljenje { get; set; }

        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}