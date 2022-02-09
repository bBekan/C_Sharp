using codeFirst.Configurations;
using System;
using System.Data.Entity;
using System.Linq;

namespace codeFirst
{
    public class codeFirstModel : DbContext
    {
        public codeFirstModel()
            : base("name=codeFirstModel")
        {
        }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new genreConfiguration());
            modelBuilder.Configurations.Add(new videoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

}