namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewRequirements : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "genre_id", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "genre_id" });
            RenameColumn(table: "dbo.Videos", name: "genre_id", newName: "genreId");
            AlterColumn("dbo.Genres", "name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "classification", c => c.Byte(nullable: false));
            AlterColumn("dbo.Videos", "genreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Videos", "genreId");
            AddForeignKey("dbo.Videos", "genreId", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "genreId", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "genreId" });
            AlterColumn("dbo.Videos", "genreId", c => c.Int());
            AlterColumn("dbo.Videos", "classification", c => c.Int(nullable: false));
            AlterColumn("dbo.Videos", "name", c => c.String());
            AlterColumn("dbo.Genres", "name", c => c.String());
            RenameColumn(table: "dbo.Videos", name: "genreId", newName: "genre_id");
            CreateIndex("dbo.Videos", "genre_id");
            AddForeignKey("dbo.Videos", "genre_id", "dbo.Genres", "id");
        }
    }
}
