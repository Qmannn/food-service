using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure( EntityTypeBuilder<Container> builder )
        {
            builder.ToTable("Containers").HasKey(container => container.Id);
            builder.Property(container => container.Name).IsRequired().HasMaxLength(40);
            builder.Property(container => container.Price).IsRequired();
        }
    }
}
