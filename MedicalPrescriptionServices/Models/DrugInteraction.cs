using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPrescription.Models
{
    [Table("DrugInteraction")]
    public class DrugInteraction
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Drug name is required.")]
        public string DrugName { get; set; }

        [Required(ErrorMessage = "Medication ID is required.")]
        public int MedicationId { get; set; }

        public string Strength { get; set; }

        public string Form { get; set; }

        [Required(ErrorMessage = "Interaction description is required.")]
        public string InteractionDescription { get; set; }

        [Required(ErrorMessage = "Drug Quantity is required.")]
        public int Quantity { get; set; }

        public string Precautions { get; set; }
    }
}
