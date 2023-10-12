namespace DigitalAgency.Models
{
    public class Contact:BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
