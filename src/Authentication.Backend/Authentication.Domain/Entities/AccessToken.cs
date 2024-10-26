using Authentication.Domain.Common;

namespace Authentication.Domain.Entities;

public class AccessToken : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public string Token { get; set; }
    public bool IsRevoked { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
}
