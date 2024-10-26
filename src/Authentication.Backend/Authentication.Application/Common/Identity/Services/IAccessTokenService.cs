using Authentication.Domain.Entities;
using System.Linq.Expressions;

namespace Authentication.Application.Common.Identity.Services;

public interface IAccessTokenService
{
    IQueryable<AccessToken> Get(Expression<Func<AccessToken, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<AccessToken?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, bool asNoTracking = false);
    ValueTask<AccessToken> CreateAsync(Guid userId, string token, bool saveChanges = true, CancellationToken cancellationToken = default);
}
