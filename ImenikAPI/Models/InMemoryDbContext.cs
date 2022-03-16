
using Microsoft.EntityFrameworkCore;

namespace ImenikAPI.Models
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<County> Counties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<County>()
                .HasOne<Country>(c => c.Country)
                .WithMany(c => c.Counties)
                .HasForeignKey(c => c.CountryId);
        }

    }
}


