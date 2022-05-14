using System.ComponentModel.DataAnnotations;

namespace EtkinlikTakvimi.Web.Entities
{
    public class Event
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        [MaxLength(15)]
        public string? textColor { get; set; }
        [MaxLength(15)]
        public string? color { get; set; }

    }
}
