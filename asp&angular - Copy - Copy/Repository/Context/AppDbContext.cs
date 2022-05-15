using Entity.Core.authentication;
using Entity.Core.world;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class AppDbContextTest : IdentityDbContext<userIdentity,roleIdentity,string>
    {
        public AppDbContextTest(DbContextOptions<AppDbContextTest> options):base(options)
        {
            
        }
        public DbSet<City>  Cities { get; set; }
        public DbSet<Countery>  Counteries { get; set; }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContextTest).Assembly);
       
    }

    }
}