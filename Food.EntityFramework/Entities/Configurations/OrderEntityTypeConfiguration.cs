using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure( EntityTypeBuilder<Order> builder )
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TotalSum);
            builder.Property(c => c.OrderDate.Date);
            builder.Property(c => c.MenuId);
            builder.Property(c => c.DeliveryDate);
            builder.Property(c => c.UserId);
        }
    }
}
