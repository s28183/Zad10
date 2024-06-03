using Zad10.Entities;

namespace Zad10.RequestModels;

public class PrescriptionRequest
{
    public PatientRequest Patient { get; set; }
    public List<MedicamentRequest> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}