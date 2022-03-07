using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (0,'Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Horror')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Drama')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Musicle')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (7,'Adventure')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (8,'Sci-fi')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (9,'Fantasy')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (10,'Documentary')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
