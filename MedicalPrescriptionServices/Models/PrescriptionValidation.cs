using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPrescriptionServices.Models
{
    [Table("PrescriptionValidation")]
    public class PrescriptionValidation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PrescriptionId { get; set; }

        [Required]
        public int SpecialistId { get; set; }

        [Required]
        public bool IsValidated { get; set; } = true;

        [StringLength(500)]
        public string Comments { get; set; }

        [Required]
        public DateTime ValidationDate { get; set; }
    }
}
