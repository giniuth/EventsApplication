using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApplication.Migrations
{
    public partial class decor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decription",
                table: "DecorDetails",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DecorDetails",
                newName: "Decription");
        }
    }
}
