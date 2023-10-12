using DigitalAgency.Models.Project;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAgency.Models.Categories
{
    public class Category 
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        [NotMapped]
        public IFormFile IconFile { get; set; }
        public List<CategoryTaranslate> Translates { get; set; }
        public List<Project.Project> Projects { get; set; }
    }
}
