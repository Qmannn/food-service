using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure( EntityTypeBuilder<Order> builder )
        {
            builder.ToTable("Orders").HasKey(order => order.Id);
            builder.Property(order => order.TotalSum);
            builder.Property(order => order.OrderDate.Date);
            builder.Property(order => order.MenuId);
            builder.Property(order => order.DeliveryDate);
            builder.Property(order => order.UserId);
        }
    }
}
