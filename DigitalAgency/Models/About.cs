using DigitalAgency.Models.Categories;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAgency.Models
{
    public class About : BaseEntity
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public List<AboutTranslate> Translates { get; set; }
    }
}
