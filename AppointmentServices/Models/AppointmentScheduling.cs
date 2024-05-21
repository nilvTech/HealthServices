using System;
using System.ComponentModel.DataAnnotations;

namespace PatientSatisfactionFeedback.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; } 
        public DateTime DateTime { get; set; }
        public int DurationMinutes { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalNotes { get; set; }
        public bool RequireConfirmation { get; set; }
    }

    public class AvailabilityCheck
    {
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
    }

    public class NotificationPreference
    {
        public string NotificationType { get; set; }
        public string Recipient { get; set; }
        public DateTime NotificationTime { get; set; }
    }
}
