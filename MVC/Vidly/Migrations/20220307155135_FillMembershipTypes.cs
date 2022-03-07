using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    public partial class FillMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MEMBERSHIPS (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (0,'Monthly', 15, 1, 0)");
            migrationBuilder.Sql("INSERT INTO MEMBERSHIPS (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (1,'Quarterly', 5, 3, 0)");
            migrationBuilder.Sql("INSERT INTO MEMBERSHIPS (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (2,'Half a year', 0, 6, 5)");
            migrationBuilder.Sql("INSERT INTO MEMBERSHIPS (Id, Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (3,'Yearly', 0, 12, 15)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
