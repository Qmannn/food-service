using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure( EntityTypeBuilder<Dish> builder )
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name);
            builder.Property(c => c.Description);
            builder.Property(c => c.Price);
            builder.Property(c => c.Category);
            builder.Property(c => c.ContainerId);
        }
    }
}
