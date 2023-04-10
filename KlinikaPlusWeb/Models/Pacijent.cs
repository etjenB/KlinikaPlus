using System.ComponentModel.DataAnnotations;

namespace KlinikaPlusWeb.Models
{
    public enum Spol
    {
        [Display(Name = "Muško")]
        Musko,
        [Display(Name = "Žensko")]
        Zensko,
        Nepoznato
    }

    public class Pacijent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ime i prezime")]
        public string ImePrezime { get; set; }

        [Required]
        [Display(Name = "Datum rođenja")]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        public Spol Spol { get; set; }

        public string? Adresa { get; set; }

        [Display(Name = "Broj telefona")]
        public string? BrojTelefona { get; set; }

        public ICollection<Prijem> PacijentPrijemi { get; set; } = new List<Prijem>();
    }
}
