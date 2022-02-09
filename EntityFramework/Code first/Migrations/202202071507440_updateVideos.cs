namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateVideos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VideoGenres", "Video_id", "dbo.Videos");
            DropForeignKey("dbo.VideoGenres", "Genre_id", "dbo.Genres");
            DropIndex("dbo.VideoGenres", new[] { "Video_id" });
            DropIndex("dbo.VideoGenres", new[] { "Genre_id" });
            AddColumn("dbo.Videos", "genre_id", c => c.Int());
            CreateIndex("dbo.Videos", "genre_id");
            AddForeignKey("dbo.Videos", "genre_id", "dbo.Genres", "id");
            DropTable("dbo.VideoGenres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VideoGenres",
                c => new
                    {
                        Video_id = c.Int(nullable: false),
                        Genre_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_id, t.Genre_id });
            
            DropForeignKey("dbo.Videos", "genre_id", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "genre_id" });
            DropColumn("dbo.Videos", "genre_id");
            CreateIndex("dbo.VideoGenres", "Genre_id");
            CreateIndex("dbo.VideoGenres", "Video_id");
            AddForeignKey("dbo.VideoGenres", "Genre_id", "dbo.Genres", "id", cascadeDelete: true);
            AddForeignKey("dbo.VideoGenres", "Video_id", "dbo.Videos", "id", cascadeDelete: true);
        }
    }
}
