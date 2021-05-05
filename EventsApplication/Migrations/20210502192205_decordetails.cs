using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApplication.Migrations
{
    public partial class decordetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DecorDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GuestCapacity = table.Column<int>(type: "int", nullable: false),
                    Decription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Alcohol = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Catering = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Cuisine = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EventTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DecorDetails_EventTypes_EventTypeID",
                        column: x => x.EventTypeID,
                        principalTable: "EventTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecorDetails_EventTypeID",
                table: "DecorDetails",
                column: "EventTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecorDetails");
        }
    }
}
