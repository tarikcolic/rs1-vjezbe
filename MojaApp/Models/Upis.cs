using WebApplication1.Models;

namespace MojaApp.Models
{
    public class Upis
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
        public DateTime DatumUpisa { get; set; }

    }
}
