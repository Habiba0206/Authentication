using Authentication.Application.Common.Identity.Services;
using Authentication.Domain.Entities;
using Authentication.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Authentication.Infrastructure.Common.Identity.Services;

public class AccessTokenService : IAccessTokenService
{
    private readonly IAccessTokenRepository _repository;

    public AccessTokenService(IAccessTokenRepository accessTokenRepository)
    {
        _repository = accessTokenRepository;
    }
    public async ValueTask<AccessToken> CreateAsync(Guid userId, string token, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var accessToken = new AccessToken
        {
            UserId = userId,
            Token = token,
        };

        return await _repository.CreateAsync(accessToken, saveChanges, cancellationToken);
    }

    public IQueryable<AccessToken> Get(Expression<Func<AccessToken, bool>>? predicate = default, bool asNoTracking = false)
    => _repository.Get(predicate, asNoTracking);

    public ValueTask<AccessToken?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, bool asNoTracking = false)
    => _repository.GetByIdAsync(id, asNoTracking);
}
