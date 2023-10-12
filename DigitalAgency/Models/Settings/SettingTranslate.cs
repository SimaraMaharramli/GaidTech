namespace DigitalAgency.Models.Settings
{
	public class SettingTranslate
	{
        public int Id { get; set; }
        public int SettingId { get; set; }
        public string Name { get; set; }
		public string LangCode { get; set; }
        public Setting Setting { get; set; }
    }
}
