using System.ComponentModel.DataAnnotations;

namespace KlinikaPlusWeb.Models
{
    public class Nalaz
    {
        [Required]
        [Display(Name = "Tekstualni opis")]
        public string TekstualniOpis { get; set; }

        [Required]
        [Display(Name = "Datum i vrijeme kreiranja")]
        public DateTime DatumIVrijemeKreiranja { get; set; }

        [Key]
        public int PrijemId { get; set; }
        public virtual Prijem Prijem { get; set; } = null!;
    }
}
