namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        releaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.VideoGenres",
                c => new
                    {
                        Video_id = c.Int(nullable: false),
                        Genre_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_id, t.Genre_id })
                .ForeignKey("dbo.Videos", t => t.Video_id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_id, cascadeDelete: true)
                .Index(t => t.Video_id)
                .Index(t => t.Genre_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoGenres", "Genre_id", "dbo.Genres");
            DropForeignKey("dbo.VideoGenres", "Video_id", "dbo.Videos");
            DropIndex("dbo.VideoGenres", new[] { "Genre_id" });
            DropIndex("dbo.VideoGenres", new[] { "Video_id" });
            DropTable("dbo.VideoGenres");
            DropTable("dbo.Videos");
            DropTable("dbo.Genres");
        }
    }
}
