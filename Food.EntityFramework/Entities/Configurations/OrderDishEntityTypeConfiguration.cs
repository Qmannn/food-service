using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class OrderDishConfiguration : IEntityTypeConfiguration<OrderDish>
    {
        public void Configure( EntityTypeBuilder<OrderDish> builder )
        {
            builder.HasKey(orderDish => new { orderDish.OrderId, orderDish.DishId });
        }
    }
}
