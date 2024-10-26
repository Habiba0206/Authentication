using Authentication.Domain.Entities;
using System.Linq.Expressions;

namespace Authentication.Persistence.Repositories.Interfaces;

public interface IAccessTokenRepository
{
    IQueryable<AccessToken> Get(Expression<Func<AccessToken, bool>>? predicate = default, bool asNoTracking = false);
    ValueTask<AccessToken?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellation = default);
}
