using System.ComponentModel.DataAnnotations;

namespace AppointmentServices.Models
{
    public class PatientSatisfaction
    {
        [Key]
        public int Id { get; set; }
        public string SurveyQuestion { get; set; }
        public int Rating { get; set; }
        public string Feedback { get; set; }

        public string Name { get; set; }

        public DateTime SurveyDate { get; set; }
    }
}
