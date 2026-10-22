using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensions.Msal;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;


//- StudentiController(StudentStorage storage) je primary constructor: kontroler kroz konstruktor dobija skladište iz DI-ja. Isti stil koristi i starter projekat.
//– [HttpGet] bez dodatka rute obrađuje GET /Studenti.
//– Select(Mapiraj) svaki entitet pretvara u DTO, pa klijent nikad ne dobija entitet.
//– Mapiraj je private, pa nije akcija: akcije su samo javne metode.
// Pokrenite projekat i u Swaggeru isprobajte GET /Studenti.


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentiController(StudentStorage storage) : Controller
    {
        [HttpGet]
        public List<StudentResponse> GetAll()
        {
            return storage.GetAll().Select(Mapiraj).ToList();
        }
        private static StudentResponse Mapiraj(Student student) => new()
        {
            Id = student.Id,
            ImePrezime = $"{student.Ime} {student.Prezime}",
            BrojIndeksa = student.BrojIndeksa,
            DatumRodjenja = student.DatumRodjenja
        };
    }
}
