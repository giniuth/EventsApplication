using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApplication.Migrations
{
    public partial class idk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecorDetails_EventTypes_EventTypeID",
                table: "DecorDetails");

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeID",
                table: "DecorDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DecorDetails_EventTypes_EventTypeID",
                table: "DecorDetails",
                column: "EventTypeID",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecorDetails_EventTypes_EventTypeID",
                table: "DecorDetails");

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeID",
                table: "DecorDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DecorDetails_EventTypes_EventTypeID",
                table: "DecorDetails",
                column: "EventTypeID",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
