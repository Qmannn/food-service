using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure( EntityTypeBuilder<Menu> builder )
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CurrentDate);
            builder.Property(c => c.StartDate);
            builder.Property(c => c.EndDate);
        }
    } 
}
