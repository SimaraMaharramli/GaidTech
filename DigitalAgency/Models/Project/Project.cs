
using DigitalAgency.Models.Categories;

namespace DigitalAgency.Models.Project
{
    public class Project 
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<ProjectTranslate> Translates { get; set; }
        public string CreateDate { get; set; }
        public List<ProjectImage> Images { get; set; }
   
    }
}
