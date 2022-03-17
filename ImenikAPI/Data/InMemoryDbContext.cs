
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
        public DbSet<AdditionalData> AdditionalData { get; set; }


    }
}


