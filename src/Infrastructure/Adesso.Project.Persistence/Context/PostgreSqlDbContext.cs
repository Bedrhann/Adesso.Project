using Adesso.Project.Domain.Entities;
using Adesso.Project.Domain.Entities.Common;
using Adesso.Project.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Adesso.Project.Persistence.Context
{
    public class PostgreSqlDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public PostgreSqlDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TravelAdvert> TravelAdverts { get; set; }
        public DbSet<TravelOffer> TravelOffers { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var Datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in Datas)
            {
                if (data.State == EntityState.Added)
                    data.Entity.CreationDate = DateTime.UtcNow;

                if (data.State == EntityState.Modified)
                    data.Entity.UpdateDate = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TravelAdvertAppUser>()
                .HasKey(ky => new { ky.AppUserId, ky.TravelAdvertId });
            base.OnModelCreating(builder);
        }
    }
}
