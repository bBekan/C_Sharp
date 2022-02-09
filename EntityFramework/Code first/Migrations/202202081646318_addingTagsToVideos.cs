namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTagsToVideos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        tagId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.tagId);
            
            CreateTable(
                "dbo.videoTags",
                c => new
                    {
                        videoId = c.Int(nullable: false),
                        tagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.videoId, t.tagId })
                .ForeignKey("dbo.Videos", t => t.videoId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.tagId, cascadeDelete: true)
                .Index(t => t.videoId)
                .Index(t => t.tagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.videoTags", "tagId", "dbo.Tags");
            DropForeignKey("dbo.videoTags", "videoId", "dbo.Videos");
            DropIndex("dbo.videoTags", new[] { "tagId" });
            DropIndex("dbo.videoTags", new[] { "videoId" });
            DropTable("dbo.videoTags");
            DropTable("dbo.Tags");
        }
    }
}
