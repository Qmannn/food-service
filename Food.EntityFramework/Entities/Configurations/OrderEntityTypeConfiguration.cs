using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure( EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order").HasKey(order => order.Id);
            builder.Property(order => order.OrderDate);
            builder.Property(order => order.DeliveryDate);

            builder.HasMany(order => order.OrderDishes)
                .WithOne(orderDish => orderDish.Order)
                .HasForeignKey(orderDish => orderDish.OrderId);

            builder.HasOne(user => user.User)
               .WithMany(order => order.Orders)
               .IsRequired();

            builder.HasOne(menu => menu.Menu)
               .WithMany(order => order.Orders)
               .IsRequired();
        }
    }
}
