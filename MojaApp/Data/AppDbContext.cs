using Microsoft.EntityFrameworkCore;
using MojaApp.Models;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Student> Studenti => Set<Student>();
        public DbSet<Smjer> Smjerovi => Set<Smjer>();
        public DbSet<Predmet> Predmeti => Set<Predmet>();
        public DbSet<Upis> Upisi => Set<Upis>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Ime = "Ana",
                    Prezime = "Anić",
                    BrojIndeksa = "IB260001",
                    DatumRodjenja = new DateOnly(2000, 1, 1),
                    DatumKreiranja = new DateTime(2026, 10, 29)
                },
                new Student()
                {
                    Id = 2,
                    Ime = "Edin",
                    Prezime = "Edić",
                    BrojIndeksa = "IB260002",
                    DatumRodjenja = new DateOnly(2001, 2, 2),
                    DatumKreiranja = new DateTime(2026, 10, 29)
                }
                );

            modelBuilder.Entity<Predmet>(e =>
            {
                e.Property(x => x.Naziv).HasMaxLength(100).IsRequired();
                e.Property(x => x.Sifra).HasMaxLength(10).IsRequired();
                e.HasIndex(x => x.Sifra).IsUnique();
            });

            modelBuilder.Entity<Student>()
                .HasOne(s=>s.Smjer)
                .WithMany(sm=> sm.Studenti)
                .HasForeignKey(s => s.SmjerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Smjer>().HasData(
                new Smjer()
                {
                    Id = 1,
                    Naziv = "Softverski inženjering"
                },
                new Smjer()
                {
                    Id = 2,
                    Naziv = "Razvoj softvera"
                }
                );

            modelBuilder.Entity<Upis>(e =>
            {
                e.HasOne(u => u.Student)
                .WithMany(s => s.Upisi)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(u => u.Predmet)
                .WithMany(s => s.Upisi)
                .HasForeignKey(s => s.PredmetId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            
        }
    }
}
