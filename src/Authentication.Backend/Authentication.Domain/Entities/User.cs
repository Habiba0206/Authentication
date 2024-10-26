using Authentication.Domain.Common;
using Authentication.Domain.Enums;

namespace Authentication.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public string PasswordHash { get; set; }
    public Status Status { get; set; }
    public bool IsEmailAddressVerified { get; set; }
    public virtual AccessToken AccessToken { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
}
