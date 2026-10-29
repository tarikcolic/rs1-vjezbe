using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using MojaApp.DTOs;
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
    public class StudentiController(AppDbContext db) : Controller
    {
        [HttpGet]
        public async Task<List<StudentResponse>> GetAll(CancellationToken ct)
        {
            List<Student> students = await db.Studenti.ToListAsync(ct);
            return students.Select(Mapiraj).ToList();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentResponse>> GetById(int id, CancellationToken ct)
        {
            var student = await db.Studenti.FindAsync(new object[] { id }, ct);

            if (student == null)
                return NotFound();

            return Mapiraj(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> Dodaj(StudentDodajRequest request, CancellationToken ct)
        {
            Student student = new Student()
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                BrojIndeksa = request.BrojIndeksa,
                DatumRodjenja = request.DatumRodjenja,
                DatumKreiranja = DateTime.Now
            };
            db.Studenti.Add(student);
            await db.SaveChangesAsync(ct);
            return Ok(Mapiraj(student));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Uredi(int id, StudentUpdateRequest request, CancellationToken ct)
        {
            Student? student = await db.Studenti.FirstOrDefaultAsync(x => x.Id == id, ct);

            if (student == null)
                return NotFound();

            student.Ime = request.Ime;
            student.Prezime = request.Prezime;
            student.DatumRodjenja = request.DatumRodjenja;

            await db.SaveChangesAsync(ct);
            return NoContent();
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
