using EvidencijaStudenata.API.Models;

namespace EvidencijaStudenata.API.Data
{
    public class StudentStorage
    {
        private readonly List<Student> _students = [];
        private int _sljedeciId = 1;

        public StudentStorage()
        {
            Dodaj(new Student()
            {
                Ime = "Marko",
                Prezime = "Markovic",
                BrojIndeksa = "12345",
                DatumRodjenja = new DateOnly(2000, 1, 1)
            });

            Dodaj(new Student()
            {
                Ime = "Jelena",
                Prezime = "Jovanovic",
                BrojIndeksa = "67890",
                DatumRodjenja = new DateOnly(2001, 2, 2)
            });
        }
        public Student Dodaj(Student student)
        {
            student.Id = _sljedeciId++;
            student.DatumKreiranja = DateTime.UtcNow;
            _students.Add(student);
            return student;
        }
        public List<Student> GetAll()
        {
            return _students;
        }
    }
}
