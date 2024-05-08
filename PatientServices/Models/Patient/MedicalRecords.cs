using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientServices.Models.Patient
{
    [Table("MedicalRecord")]
    public class MedicalRecord
    {
        [Key]
        public int RecordId { get; set; }

        [Required(ErrorMessage = "PatientId is required")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Diagnosis is required")]
        public string Diagnosis { get; set; }

        [Required(ErrorMessage = "Treatment is required")]
        public string Treatment { get; set; }
    }
}
