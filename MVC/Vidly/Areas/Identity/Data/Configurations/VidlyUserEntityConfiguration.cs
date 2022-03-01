using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly.Areas.Identity.Data;

namespace Vidly.Data
{
    internal class VidlyUserEntityConfiguration : IEntityTypeConfiguration<VidlyUser>
    {
        public void Configure(EntityTypeBuilder<VidlyUser> builder)
        {

            builder.Property(u => u.DrivingLicense)
                .HasMaxLength(50);
        }
    }
}