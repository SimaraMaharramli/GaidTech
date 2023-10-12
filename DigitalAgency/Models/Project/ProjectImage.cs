namespace DigitalAgency.Models.Project
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string Image { get; set; }
    }
}
