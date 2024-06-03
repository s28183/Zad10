using Microsoft.AspNetCore.Mvc;
using Zad10.RequestModels;
using Zad10.Services;

namespace Zad10.Controllers;

[Route("api/prescripton")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private IPrescriptionService _service;
    [HttpPost]
    public IActionResult AddPrescription(PrescriptionRequest prescriptionRequest)
    {
        
        return Ok(prescriptionRequest);
    }
}