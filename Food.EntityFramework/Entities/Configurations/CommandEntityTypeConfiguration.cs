using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    public class CommandEntityTypeConfiguration : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder.ToTable("Commands");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(255);
        }
    }
}