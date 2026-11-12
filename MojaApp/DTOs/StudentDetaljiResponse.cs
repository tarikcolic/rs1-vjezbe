namespace MojaApp.DTOs
{
    public class StudentDetaljiResponse
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; } = "";
        public string BrojIndeksa { get; set; } = "";
        public DateOnly? DatumRodjenja { get; set; }
        public string? Smjer { get; set; }
        public List<StudentUpisResponse> Upisi { get; set; } = [];
    }

    public class StudentUpisResponse
    {
        public int Id { get; set; }
        public string NazivPredmeta { get; set; } = "";
        public string Sifra { get; set; } = "";
        public DateTime DatumUpisa { get; set; }
    }
}
