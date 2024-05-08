using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPrescriptionServices.Models
{
    [Table("PrescriptionHistory")]
    public class PrescriptionHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PrescriptionId { get; set; }

        [Required]
        public string FieldName { get; set; }

        [Required]
        public string OldValue { get; set; }

        [Required]
        public string NewValue { get; set; }

        public DateTime ChangeDate { get; set; }
    }
}
