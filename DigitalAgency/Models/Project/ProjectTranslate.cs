namespace DigitalAgency.Models.Project
{
    public class ProjectTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string LangCode { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
