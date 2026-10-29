using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace MojaApp.DTOs
{
    public class StudentDodajRequest
    {
        [Required]
        public string Ime { get; set; } = "";

        [Required]
        public string Prezime { get; set; } = "";

        [Required]
        public string BrojIndeksa { get; set; } = "";

        // neobavezno polje
        public DateOnly? DatumRodjenja { get; set; }
    }
}
