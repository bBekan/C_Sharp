using DatabaseDesignChallenge.Configurations;
using System;
using System.Data.Entity;
using System.Linq;

namespace DatabaseDesignChallenge
{
    public class ChristmasPresents : DbContext
    {
        // Your context has been configured to use a 'ChristmasPresents' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DatabaseDesignChallenge.ChristmasPresents' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ChristmasPresents' 
        // connection string in the application configuration file.
        public ChristmasPresents()
            : base("name=ChristmasPresents")
        {
        }
        public virtual DbSet<Person> FriendsAndFamily { get; set; } 
        public virtual DbSet<Present> Presents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new presentConfig());
            modelBuilder.Configurations.Add(new personConfig());
            base.OnModelCreating(modelBuilder);
        }

    }

}