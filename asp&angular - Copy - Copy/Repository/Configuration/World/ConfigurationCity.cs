using Entity.Core.world;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.World
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).IsRequired();
            builder.Property(d => d.Lat).HasPrecision(4, 3);
            builder.Property(d => d.Lon).HasPrecision(4, 3);
            builder.HasOne(d => d.Countery).
                WithMany(d => d.Cities).
                HasForeignKey(d => d.CounteryId).HasConstraintName("CounteryIdFk").
                OnDelete(deleteBehavior: DeleteBehavior.Cascade);

        }
    }

}