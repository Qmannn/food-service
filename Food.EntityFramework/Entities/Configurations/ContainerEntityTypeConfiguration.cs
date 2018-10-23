using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure( EntityTypeBuilder<Container> builder )
        {
            builder.ToTable("Container").HasKey(container => container.Id);
            builder.Property(container => container.Name).IsRequired().HasMaxLength(500);
        }
    }
}
