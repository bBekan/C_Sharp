namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "Genre_id", "dbo.Genres");
            Sql("DELETE FROM Genres WHERE Id BETWEEN 1 AND 3");
            Sql("DELETE FROM Videos WHERE Id between 1 and 3");
            AddForeignKey("dbo.Videos", "Genre_id", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //Just fixing up the db so no need for down
        }
    }
}
