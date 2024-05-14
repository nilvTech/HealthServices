namespace PatientServices.Models
{
    public class NotificationMailSettings
    {
        public  string Host { get; } = "smtp.com";
        public  int Port { get; } = 587;
        public  string SenderMail { get; } = "notify.adminhost@gmail.com";
        public  string Password { get; } = "password";
    }
}
