using System.ComponentModel.DataAnnotations;

namespace MedicalPrescription.Models
{
    public class DrugInteraction
    {
        public int DrugInteractionId { get; set; }

        [Required]
        public int MedicationId { get; set; }

        [Required]
        public string InteractionDescription { get; set; }
    }
}
