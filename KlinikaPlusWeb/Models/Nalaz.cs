using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlinikaPlusWeb.Models
{
    public class Nalaz
    {
        [Required]
        [Display(Name = "Tekstualni opis")]
        public string TekstualniOpis { get; set; }

        [Required]
        [Display(Name = "Datum i vrijeme kreiranja")]
        public DateTime DatumIVrijemeKreiranja { get; set; } = DateTime.Now;

        [Key]
        //public int Id { get; set; }
        public int PrijemId { get; set; }
        public virtual Prijem? Prijem { get; set; } = null!;
    }
}
