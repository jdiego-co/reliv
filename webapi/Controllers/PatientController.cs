using domain;
using domain.DTO;
using Microsoft.AspNetCore.Mvc;
using service;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;
    private readonly IPatientService _patientService;

    public PatientController(ILogger<PatientController> logger, IPatientService patientService)
    {
        _logger = logger;
        _patientService = patientService;
    }
    /// <summary>
    /// Gets all patients currently stored 
    /// </summary>
    /// <returns>List of Patient objects</returns>
    [HttpGet]
    public DTOActionResponse<IEnumerable<Patient>> GetAll()
    {
        var response = new DTOActionResponse<IEnumerable<Patient>>();
        try
        {
            response.Value = _patientService.GetAll();
            response.IsSuccess = true;
        }
        catch(Exception e)
        {
            _logger.LogError(e, "An error occurred");
            response.Message = "Something wrong happened";
        }
        return response;
    }
    /// <summary>
    /// Finds a single patient by Id field
    /// </summary>
    /// <param name="id">Value to identity the patient</param>
    /// <returns>Patient object found or null</returns>
    [HttpGet("{id}")]
    public DTOActionResponse<Patient> Get(int id)
    {
        var response = new DTOActionResponse<Patient>();
        try
        {
            response.Value = _patientService.Get(id);
            response.IsSuccess = true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred");
            response.Message = "Something wrong happened";
        }
        return response;
    }

    /// <summary>
    /// Creates a new patient who contains all required data
    /// </summary>
    /// <param name="model">Patient object with at least contains First Name and Last Name</param>
    /// <returns>Patient object with respective Id field populated</returns>
    [HttpPost(Name = "CreatePatient")]
    public DTOActionResponse<Patient> Post(Patient model)
    {
        var response = new DTOActionResponse<Patient>();
        try
        {
            response.Value = _patientService.Add(model);
            response.IsSuccess = true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred");
            response.Message = "Something wrong happened";
        }
        return response;
    }
    /// <summary>
    /// Edits an existant patient
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut(Name = "EditPatient")]
    public DTOActionResponse<bool> Edit(Patient model)
    {
        var response = new DTOActionResponse<bool>();
        try
        {
            response.Value = _patientService.Update(model);
            response.IsSuccess = true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred");
            response.Message = "Something wrong happened";
        }
        return response;
    }
    /// <summary>
    /// Removes an existant pacient
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete(Name = "RemovePatient")]
    public DTOActionResponse<bool> Remove(Patient model)
    {
        var response = new DTOActionResponse<bool>();
        try
        {
            response.Value = _patientService.Delete(model);
            response.IsSuccess = true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred");
            response.Message = "Something wrong happened";
        }
        return response;
    }
}
