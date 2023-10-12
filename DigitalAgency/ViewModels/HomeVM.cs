using DigitalAgency.Models;
using DigitalAgency.Models.Project;

namespace DigitalAgency.ViewModels
{
    public class HomeVM
    {
        public List<About> Abouts { get; set; }
        //public List<Client> Clients { get; set; }
        public List<GetallHeader> Headers { get; set; }
        public List<Message> Messages { get; set; }
        //public List<Pricing> Pricings { get; set; }
        public List<GetAllProject> Projects { get; set; }
        public List<GetAllCategory> Categories { get; set; }
        public List<GetallService> Services { get; set; }
        public List<Team> Teams { get; set; }
        public string LangCode { get; set; }
    }
}
