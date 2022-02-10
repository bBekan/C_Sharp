using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesignChallenge.Configurations
{
    public class presentConfig : EntityTypeConfiguration<Present>
    {
        public presentConfig()
        {
            Property(p => p.cost)
                .IsRequired();

            Property(p => p.name)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
