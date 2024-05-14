namespace PatientServices.Models
{
    public class NotificationRequest
    {
        public string Host { get; } = "smtp.com";
        public int Port { get; } = 587;
        public string SenderMail { get; } = "notify.adminhost@gmail.com";
        public string Password { get; } = "password";
        public string ToEmail { get; set; } = "patient2024@gmail.com";
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
