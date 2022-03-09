using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Horror')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Drama')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (7,'Musicle')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (8,'Adventure')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (9,'Sci-fi')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (10,'Fantasy')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (11,'Documentary')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
