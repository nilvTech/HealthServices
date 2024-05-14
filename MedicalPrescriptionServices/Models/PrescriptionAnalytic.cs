namespace MedicalPrescriptionServices.Models
{
     public class PrescriptionAnalytic
        {
            public int Id { get; set; }
            public string DrugName { get; set; }
            public int Quantity { get; set; }
            public decimal TotalCost { get; set; }
            public DateTime DatePrescribed { get; set; }
            public string PrescriptionType { get; set; }
            public string PrescriptionStatus { get; set; }
            public int PatientId { get; set; }            
            public string DrugInteractionId { get; set; }
        }
    

}
