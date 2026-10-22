using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    // Privremeno skladište u memoriji: podaci nestaju kad se aplikacija ugasi.
    // Registrovano kao singleton u Program.cs. Na narednim vježbama ga zamjenjuje baza (EF Core).
    //– Lista _studenti je private: drugi dijelovi aplikacije do studenata dolaze samo preko metoda.
    //– _sljedeciId dodjeljuje Id redom, kao što to kasnije radi baza.
    //– Konstruktor ubacuje dva studenta, da imate podatke za testiranje.
    //– GetById vraća null kad student ne postoji, zato je povratni tip Student?.
    //– Sitnice iz C#-a: [] je prazna lista, => je metoda u jednom redu, a FirstOrDefault (LINQ) vraća prvi element koji odgovara uslovu ili null.
    public class StudentStorage
    {
        private readonly List<Student> _studenti = [];
        private int _sljedeciId = 1;

        public StudentStorage()
        {
            Dodaj(new Student 
            { 
                Ime = "Marko", 
                Prezime = "Marković", 
                BrojIndeksa = "IB223456", 
                DatumRodjenja = new DateOnly(2000, 1, 1) 
            });
            
            Dodaj(new Student 
            { 
                Ime = "Ana", 
                Prezime = "Anić", 
                BrojIndeksa = "IB240034", 
                DatumRodjenja = new DateOnly(2001, 2, 2) 
            });
        }

        public List<Student> GetAll() => _studenti;
        public Student? GetById(int id) => _studenti.FirstOrDefault(
            x => x.Id == id);

        public Student Dodaj(Student student)
        {
            student.Id = _sljedeciId++; // prvo dodijeli 1, pa zatim uveca
            student.DatumKreiranja = DateTime.Now;
            _studenti.Add(student);
            return student;
        }
    }
}
