using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class OrderDishConfiguration : IEntityTypeConfiguration<OrderDish>
    {
        public void Configure( EntityTypeBuilder<OrderDish> builder )
        {
            builder.ToTable("OrderDish").HasKey(orderDish => orderDish.Id);
            builder.Property(orderDish => orderDish.DishName).IsRequired().HasMaxLength(500);
        }
    }
}
