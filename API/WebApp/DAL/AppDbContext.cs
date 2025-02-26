using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Password> Passwords { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .HasMany(a => a.Passwords)
                .WithOne(p => p.Application)
                .HasForeignKey(p => p.ApplicationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
