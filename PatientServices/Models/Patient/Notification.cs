using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientServices.Models.Patient
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

        public bool IsRead { get; set; }= true;

        [Required(ErrorMessage = "SentDateTime is required")]
        [DataType(DataType.DateTime)]
        public DateTime SentDateTime { get; set; }
    }
}
