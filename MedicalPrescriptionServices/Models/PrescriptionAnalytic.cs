namespace MedicalPrescriptionServices.Models
{
     public class PrescriptionAnalytic
        {
            public int Id { get; set; }
            public string DrugName { get; set; }
            public int Quantity { get; set; }
            public int TotalCost { get; set; }
            public DateTime DatePrescribed { get; set; }
            public string PrescriptionType { get; set; }
            public string PrescriptionStatus { get; set; }
            public int PatientId { get; set; }            
            public int DrugInteractionId { get; set; }
        }
    

}
