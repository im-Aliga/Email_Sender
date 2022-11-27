using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSender.Migrations
{
    public partial class RelationShipEmailAndNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DBNotification_EmailModelId",
                table: "DBNotification",
                column: "EmailModelId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
