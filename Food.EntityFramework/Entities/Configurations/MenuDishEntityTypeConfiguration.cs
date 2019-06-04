using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    class MenuDishConfiguration : IEntityTypeConfiguration<MenuDish>
    {
        public void Configure( EntityTypeBuilder<MenuDish> builder )
        {
            builder.HasKey(menuDish => menuDish.Id);
        }
    }
}
