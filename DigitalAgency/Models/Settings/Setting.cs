namespace DigitalAgency.Models.Settings
{
	public class Setting
	{
        public int Id { get; set; }
        public string Logo { get; set; }
        public List<SettingTranslate> Translates { get; set; }
    }
}
