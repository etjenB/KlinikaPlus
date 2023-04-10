using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlinikaPlusWeb.Models
{
    public class Prijem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Datum i vrijeme prijema")]
        public DateTime DatumIVrijeme { get; set; }

        [Required]
        [Display(Name = "Hitan prijem")]
        public bool HitanPrijem { get; set; } = false;

        //Foreign Key na tabelu Ljekar
        [ForeignKey("Ljekar")]
        public int? LjekarId { get; set; }
        public virtual Ljekar? Ljekar { get; set; }

        //Foreign Key na tabelu Pacijent
        [ForeignKey("Pacijent")]
        public int? PacijentId { get; set; }
        public virtual Pacijent? Pacijent { get; set; }

        //Foreign Key na tabelu Nalaz
        [ForeignKey("Nalaz")]
        public int? NalazId { get; set; }
        public virtual Nalaz? Nalaz { get; set; }
    }
}
