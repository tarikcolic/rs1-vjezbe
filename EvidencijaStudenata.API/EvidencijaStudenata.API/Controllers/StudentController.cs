using EvidencijaStudenata.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using EvidencijaStudenata.API.Models;
using EvidencijaStudenata.API.Data;

namespace EvidencijaStudenata.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(StudentStorage studentStorage) : Controller
    {
        [HttpGet]
        public List<StudentResponse> GetAll()
        {
            List<Student> students = studentStorage.GetAll();
            return students.Select(Mapiraj).ToList();
        }
        private static StudentResponse Mapiraj(Student s)
        {
            return new StudentResponse()
            {
                Id = s.Id,
                ImePrezime = $"{s.Ime} {s.Prezime}",
                BrojIndeksa = s.BrojIndeksa,
                DatumRodjenja = s.DatumRodjenja
            };
        }
    }
}
