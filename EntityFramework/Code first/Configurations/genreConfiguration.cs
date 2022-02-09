using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeFirst.Configurations
{
    public class genreConfiguration : EntityTypeConfiguration<Genre>
    {
        public genreConfiguration()
        {
            Property(g => g.name)
            .IsRequired()
            .HasMaxLength(255);
        }
    }
}
