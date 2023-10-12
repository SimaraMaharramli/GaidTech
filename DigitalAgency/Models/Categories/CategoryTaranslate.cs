namespace DigitalAgency.Models.Categories
{
    public class CategoryTaranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string LangCode { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
