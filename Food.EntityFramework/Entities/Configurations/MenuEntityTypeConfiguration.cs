using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure( EntityTypeBuilder<Menu> builder )
        {
            builder.ToTable("Menu").HasKey(menu => menu.Id);

            builder.HasMany(menu => menu.MenuDishes)
                .WithOne(menuDish => menuDish.Menu)
                .HasForeignKey(menuDish => menuDish.MenuId);
        }
    } 
}
