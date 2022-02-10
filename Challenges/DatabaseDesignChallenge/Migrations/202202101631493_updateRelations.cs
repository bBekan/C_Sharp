namespace DatabaseDesignChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Presents", "recipient_personId", "dbo.People");
            DropIndex("dbo.Presents", new[] { "recipient_personId" });
            AlterColumn("dbo.Presents", "recipient_personId", c => c.Int(nullable: false));
            CreateIndex("dbo.Presents", "recipient_personId");
            AddForeignKey("dbo.Presents", "recipient_personId", "dbo.People", "personId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Presents", "recipient_personId", "dbo.People");
            DropIndex("dbo.Presents", new[] { "recipient_personId" });
            AlterColumn("dbo.Presents", "recipient_personId", c => c.Int());
            CreateIndex("dbo.Presents", "recipient_personId");
            AddForeignKey("dbo.Presents", "recipient_personId", "dbo.People", "personId");
        }
    }
}
