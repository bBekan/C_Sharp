namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<codeFirst.codeFirstModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "codeFirst.codeFirstModel";
        }
        protected override void Seed(codeFirst.codeFirstModel context)
        {
        }
    }
}
