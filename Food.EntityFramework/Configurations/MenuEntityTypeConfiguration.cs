using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure( EntityTypeBuilder<Menu> builder )
        {
            builder.ToTable("Menus").HasKey(menu => menu.Id);
            builder.Property(menu => menu.CurrentDate);
            builder.Property(menu => menu.StartDate);
            builder.Property(menu => menu.EndDate);
        }
    } 
}
