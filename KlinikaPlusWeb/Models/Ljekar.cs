using System.ComponentModel.DataAnnotations;

namespace KlinikaPlusWeb.Models
{
    public enum Titula
    {
        Specijalista,
        Specijalizant,
        [Display(Name = "Medicinska Sestra")]
        MedicinskaSestra
    }

    public class Ljekar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        [Display(Name = "Šifra")]
        public string Sifra { get; set; }

        public ICollection<Prijem> LjekarPrijemi { get; set; } = new List<Prijem>();
    }
}
