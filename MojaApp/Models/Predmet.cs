namespace MojaApp.Models
{
    public class Predmet
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = "";
        public string Sifra { get; set; } = "";
        public int ECTS { get; set; }

        public List<Upis> Upisi { get; set; } = [];
    }
}
