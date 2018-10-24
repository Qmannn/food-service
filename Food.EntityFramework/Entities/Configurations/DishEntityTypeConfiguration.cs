using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure( EntityTypeBuilder<Dish> builder )
        {
            builder.ToTable("Dish").HasKey(dish => dish.Id);
            builder.Property(dish => dish.Name).IsRequired().HasMaxLength(500);

            builder.HasMany(dish => dish.MenuDishes)
                .WithOne(menuDish => menuDish.Dish)
                .HasForeignKey(menuDish => menuDish.DishId);

            builder.HasOne(dish => dish.Container)
                .WithMany(container => container.Dishes)
                .HasForeignKey(dish => dish.ContainerId)
                .IsRequired();
        }
    }
}
