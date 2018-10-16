using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class DishEntityTypeConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure( EntityTypeBuilder<Dish> builder )
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(20);
            builder.Property(c => c.Description).HasMaxLength(300);
            builder.Property(c => c.Price);
            builder.Property(c => c.Category).HasMaxLength(20);
            builder.Property(c => c.IdContainer);
        }
    }
}
