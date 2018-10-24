using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure( EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order").HasKey(order => order.Id);

            builder.HasOne(order => order.OrderDishes)
                .WithOne(orderDish => orderDish.Order)
                .HasForeignKey(orderDish => orderDish.OrderId);

            builder.HasOne(order => order.User)
               .WithMany(user => user.Orders)
               .HasForeignKey(order => order.UserId)
               .IsRequired();

            builder.HasOne(order => order.Menu)
               .WithMany(menu => menu.Orders)
               .HasForeignKey(order => order.MenuId)
               .IsRequired();
        }
    }
}
