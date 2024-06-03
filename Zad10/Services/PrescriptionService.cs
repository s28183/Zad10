﻿using Zad10.Entities;
using Zad10.RequestModels;

namespace Zad10.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly HospitalDbContext _DbContext;

    public PrescriptionService(HospitalDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public bool AddPrescription(PrescriptionRequest request)
    {
        Patient? patient = _DbContext.Patients.Find(request.Patient.IdPatient);
        if (patient == null)
        {
            patient = new Patient()
            {
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                Birthdate = request.Patient.Birthdate
            };
            _DbContext.Patients.Add(patient);
        }

        if (request.Medicaments.Count > 10 || request.DueDate < request.Date)
            return false;

        List<Medicament> medicaments = new List<Medicament>();
        foreach (var medicament in request.Medicaments)
        {
            Medicament? found = _DbContext.Medicaments.Find(medicament.IdMedicament);
            if (found == null)
                return false;
            medicaments.Add(found);
        }

        Prescription toAdd = new Prescription()
        {
            Date = request.Date,
            DueDate = request.DueDate,
            Doctor = _DbContext.Doctors.First(d => d.IdDoctor == 1),
            Patient = patient
        };

        List<PrescriptionMedicament> prescriptionMedicaments = new List<PrescriptionMedicament>();
        foreach (var medicament in medicaments)
        {
            prescriptionMedicaments.Add(new PrescriptionMedicament()
            {
                Dose = 1,
                Details = "",
                MedicamentId = medicament.IdMedicament,
                PrescriptionId = toAdd.IdPrescription,
                Medicament = medicament,
                Prescription = toAdd
            });
        }

        toAdd.PrescriptionMedicaments = prescriptionMedicaments;
        _DbContext.SaveChanges();
        return true;
    }
}