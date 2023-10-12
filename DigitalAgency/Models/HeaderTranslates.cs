namespace DigitalAgency.Models
{
    public class HeaderTranslates
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string Head { get; set; }
        public string Desc { get; set; }
        public string LangCode { get; set; }
    
        public Header Header { get; set; }
    }
}
