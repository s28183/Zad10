using Zad10.RequestModels;

namespace Zad10.Services;

public interface IPrescriptionService
{
    public bool AddPrescription(PrescriptionRequest request);
}