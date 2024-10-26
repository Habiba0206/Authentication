namespace Authentication.Domain.Common;

public interface IEntity
{
    Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
}
