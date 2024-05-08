using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPrescriptionServices.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int MedicationId { get; set; }

        [Required]
        public DateTime PrescribedDate { get; set; }

        public DateTime? DispensedDate { get; set; }

        public string DosageInstructions { get; set; }

        public bool IsElectronic { get; set; }

    }
}
