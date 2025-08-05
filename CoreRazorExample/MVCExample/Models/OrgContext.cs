using Microsoft.EntityFrameworkCore;

namespace MVCExample.Models
{
    public class OrgContext : DbContext
    {
        public OrgContext(DbContextOptions<OrgContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity using Fluent API
            modelBuilder.Entity<OrgLocation>(entity =>
            {
                entity.HasKey(e => new { e.OrgId, e.LocationId });  // 👈 Composite PK
            });
        }

        public int ID { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Location> locations { get; set; }

        public DbSet<OrgLocation> orglocations { get; set; }

    }
}
