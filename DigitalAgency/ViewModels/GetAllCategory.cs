namespace DigitalAgency.ViewModels
{
    public class GetAllCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string LangCode { get; set; }
        public List<GetAllProject> Projects { get; set; }
    }
}
