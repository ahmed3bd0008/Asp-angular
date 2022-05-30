using Entity.Core.world;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.World
{
    public class CounteryConfiguration : IEntityTypeConfiguration<Countery>
    {
        public void Configure(EntityTypeBuilder<Countery> builder)
        {
            builder.ToTable("Counteries");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).IsRequired();
            builder.HasMany(d => d.Cities).
                WithOne(d => d.Countery).
                HasForeignKey(d => d.CounteryId).HasConstraintName("CounteryIdFk").
                OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }

}