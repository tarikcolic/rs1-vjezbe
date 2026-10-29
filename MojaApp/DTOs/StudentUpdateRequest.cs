using System.ComponentModel.DataAnnotations;

namespace MojaApp.DTOs
{
    public class StudentUpdateRequest
    {
        // Ono što klijent šalje. Id i DatumKreiranja postavlja server, pa ih ovdje nema.

        [Required, StringLength(50)]
        public string Ime { get; set; } = "";

        [Required, StringLength(50)]
        public string Prezime { get; set; } = "";

        public DateOnly? DatumRodjenja { get; set; }
    }
}
