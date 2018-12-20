using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Entities.Configurations
{
    public class SampleEntityTypeConfiguration: IEntityTypeConfiguration<Sample>
    {
        public void Configure( EntityTypeBuilder<Sample> builder )
        {
            builder.ToTable( "Sample" );
            builder.HasKey( s => s.Id );
            builder.Property( s => s.Name ).HasMaxLength( 255 );
        }
    }
}