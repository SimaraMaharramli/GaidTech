namespace DigitalAgency.Models
{
    public class AboutTranslate : BaseEntity
    {
        public string Head { get; set; }
        public string SecondHead { get; set; }
        public string Desc { get; set; }
        public string LangCode { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
