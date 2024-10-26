using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.EntityComfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(u => u.AccessToken)           
        .WithOne(at => at.User)               
        .HasForeignKey<AccessToken>(at => at.UserId);
    }
}
