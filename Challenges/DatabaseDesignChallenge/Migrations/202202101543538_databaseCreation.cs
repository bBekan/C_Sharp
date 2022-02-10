namespace DatabaseDesignChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        personId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 20),
                        surname = c.String(nullable: false, maxLength: 20),
                        address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.personId);
            
            CreateTable(
                "dbo.Presents",
                c => new
                    {
                        presentId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        cost = c.Double(nullable: false),
                        recipient_personId = c.Int(),
                    })
                .PrimaryKey(t => t.presentId)
                .ForeignKey("dbo.People", t => t.recipient_personId)
                .Index(t => t.recipient_personId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Presents", "recipient_personId", "dbo.People");
            DropIndex("dbo.Presents", new[] { "recipient_personId" });
            DropTable("dbo.Presents");
            DropTable("dbo.People");
        }
    }
}
