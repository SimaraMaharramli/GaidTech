using DigitalAgency.Areas.Adminarea.ViewModels.Category;

namespace DigitalAgency.Areas.Adminarea.ViewModels.About
{
    public class AboutVM
    {
        public IFormFile Image { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public List<AboutTranslateVM> Translates { get; set; }
    }
}
