using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.EntityComfigurations;

public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
{
    public void Configure(EntityTypeBuilder<AccessToken> builder)
    {
        builder
            .HasOne(accesToken => accesToken.User)
            .WithOne()
            .HasForeignKey<AccessToken>(token => token.UserId);
    }
}
