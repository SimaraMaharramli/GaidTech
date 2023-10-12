using DigitalAgency.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAgency.ViewModels
{
	public class GetAllAbout
	{
		public string Image { get; set; }
		[NotMapped]
		public string Location { get; set; }
		public string Email { get; set; }
		public long Phone { get; set; }
		public string Head { get; set; }
		public string SecondHead { get; set; }
		public string Desc { get; set; }
		public string LangCode { get; set; }
	}
}
