using System.ComponentModel.DataAnnotations;

namespace Authentication.Application.Common.Identity.Models;

public class RegisterDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
