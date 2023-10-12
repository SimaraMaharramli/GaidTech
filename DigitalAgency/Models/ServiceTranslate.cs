namespace DigitalAgency.Models
{
    public class ServiceTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string LangCode { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
