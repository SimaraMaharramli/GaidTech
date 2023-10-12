namespace DigitalAgency.Models
{
    public class Header 
    {
        public int Id { get; set; }
        public List<HeaderTranslates> Translates { get; set; }
        public string Image { get; set; }

    }
}
