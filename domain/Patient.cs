using System.ComponentModel.DataAnnotations;

namespace domain;
public class Patient
{
    public int PatientID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthday { get; set; }
    public string? CedulaIdentidad { get; set; }
    public string? PatientPhone { get; set; }
    public string? PatientCellPhone { get; set; }
    public string? PatientEmail { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
}
