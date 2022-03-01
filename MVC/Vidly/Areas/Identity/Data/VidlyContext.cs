using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly.Areas.Identity.Data;
using Vidly.Models;

namespace Vidly.Data;

public class VidlyContext : IdentityDbContext<VidlyUser>
{

    public VidlyContext(DbContextOptions<VidlyContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new VidlyUserEntityConfiguration());

    }

    public DbSet<Vidly.Models.Movie> Movie { get; set; }

    public DbSet<Vidly.Models.Customer> Customer { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Rental> Rentals { get; set; }
}
