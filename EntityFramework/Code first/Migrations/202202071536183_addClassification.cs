namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClassification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "classification", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "classification");
        }
    }
}
