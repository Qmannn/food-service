using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure( EntityTypeBuilder<Dish> builder )
        {
            builder.ToTable("Dishes").HasKey(dish => dish.Id);
            builder.Property(dish => dish.Name).IsRequired().HasMaxLength(40);
            builder.Property(dish => dish.Description).IsRequired().HasMaxLength(400);
            builder.Property(dish => dish.Price);
            builder.Property(dish => dish.Category).IsRequired().HasMaxLength(40);
            builder.Property(dish => dish.ContainerId);
        }
    }
}
