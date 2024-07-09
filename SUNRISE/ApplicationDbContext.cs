using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SUNRISE.Models;

namespace SUNRISE
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUserEntity, ApplicationUserRoleEntity, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Chef>()
                .ToTable(nameof(Chef))
                .HasKey(k => k.Id);

            builder.Entity<Chef>()
                .Property<string>(c => c.FirstName)
                .HasMaxLength(50);

            builder.Entity<Chef>()
                .Property<string>(c => c.LastName)
                .HasMaxLength(50);

        }

        public virtual DbSet<Chef> ChefSet { get; set; }
    }
}
