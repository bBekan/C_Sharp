using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace codeFirst.Configurations
{
    public class videoConfiguration : EntityTypeConfiguration<Video> 
    { 
        public videoConfiguration()
        {
            Property(v => v.name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(v => v.genre)
                .WithMany(g => g.videos)
                .HasForeignKey(v => v.genreId);

            HasMany(v => v.tags)
                .WithMany(t => t.videos)
                .Map(m =>
                {
                    m.ToTable("videoTags");
                    m.MapLeftKey("videoId");
                    m.MapRightKey("tagId");
                });
    }
    }
}
