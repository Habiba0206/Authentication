using Authentication.Domain.Entities;
using Authentication.Persistence.DataContexts;
using Authentication.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Authentication.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User>, IUserRepository
{
    public UserRepository(IdentityDbContext dbContext) : base(dbContext)
    {

    }
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    => base.Get(predicate, asNoTracking);

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdAsync(id, asNoTracking, cancellation);

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdsAsync(ids, asNoTracking, cancellation);

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    => base.CreateAsync(user, saveChanges, cancellation);

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    {
        var foundUser = await GetByIdAsync(user.Id, cancellation: cancellation) ?? throw new InvalidOperationException();

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.Age = user.Age;
        foundUser.EmailAddress = user.EmailAddress;
        foundUser.PasswordHash = user.PasswordHash;

        return await base.UpdateAsync(user, saveChanges, cancellation);
    }


    public ValueTask<User?> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteAsync(user, saveChanges, cancellation);

    public ValueTask<User?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteByIdAsync(id, saveChanges, cancellation);
}
