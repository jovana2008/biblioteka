using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Pozajmice")]
    public class PozajmiceModel
    {
        [Key]
        public int Id { get; set; }

        public int UcenikId { get; set; }
        public int KnjigaId { get; set; }

        public DateTime DatumPozajmice { get; set; }
     
        public DateTime? DatumVracanja { get; set; }

        public virtual UcenikModel Ucenik { get; set; }

        public virtual KnjigaModel Knjiga { get; set; }
    }
}