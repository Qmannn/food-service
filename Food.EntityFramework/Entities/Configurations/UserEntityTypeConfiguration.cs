using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder )
        {
            builder.ToTable("User").HasKey(user => user.Id);
            builder.Property(user => user.Name).IsRequired().HasMaxLength(500);

            builder.HasMany(order => order.Orders)
                .WithOne(user => user.User)
                .IsRequired();
        }
    }
}
