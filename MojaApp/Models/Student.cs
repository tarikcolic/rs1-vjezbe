using MojaApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Models
{
    public class Student
    {
        //– = "" daje početnu vrijednost: string tako nikad nije null.
        //– DateOnly? je datum bez vremena.Znak? znači da polje može ostati prazno.
        //– Id i DatumKreiranja postavlja server, ne klijent
        public int Id { get; set; }
        public string Ime { get; set; } = "";
        public string Prezime { get; set; } = "";
        public string BrojIndeksa { get; set; } = "";
        public DateOnly? DatumRodjenja { get; set; }
        public DateTime DatumKreiranja { get; set; }

        public int? SmjerId { get; set; } // nullable da se ne bi obrisalo sve iz baze kada migriramo
        public Smjer? Smjer { get; set; }

    }
}
