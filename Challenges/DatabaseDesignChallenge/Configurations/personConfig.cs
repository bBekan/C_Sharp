using DatabaseDesignChallenge;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class personConfig : EntityTypeConfiguration<Person>
{
    public personConfig()
    {
         Property(p => p.address)
            .IsRequired()
            .HasMaxLength(50);

        Property(p => p.name)
            .IsRequired()
            .HasMaxLength(20);

        Property(p => p.surname)
            .IsRequired()
            .HasMaxLength(20);

        HasMany(p => p.presents)
            .WithRequired(r => r.recipient);


    }
}