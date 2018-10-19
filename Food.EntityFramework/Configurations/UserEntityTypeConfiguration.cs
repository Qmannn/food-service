using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder )
        {
            builder.ToTable("Users").HasKey(user => user.Id);
            builder.Property(user => user.Role).IsRequired().HasMaxLength(40);
            builder.Property(user => user.Name).IsRequired().HasMaxLength(40);
        }
    }
}
