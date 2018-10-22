using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure( EntityTypeBuilder<Menu> builder )
        {
            builder.ToTable("Menu").HasKey(menu => menu.Id);
            builder.Property(menu => menu.CurrentDate);
            builder.Property(menu => menu.StartDate);
            builder.Property(menu => menu.EndDate);

            builder.HasMany(menu => menu.MenuDishes)
                .WithOne(menuDishes => menuDishes.Menu)
                .HasForeignKey(menuDish => menuDish.MenuId);

            builder.HasMany(order => order.Orders)
                .WithOne(menu => menu.Menu)
                .IsRequired();
        }
    } 
}
