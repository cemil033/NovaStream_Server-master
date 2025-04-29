using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovaStream.Persistence.Migrations
{
    public partial class Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtitles_Serials_SerialId",
                table: "Subtitles");

            migrationBuilder.DropIndex(
                name: "IX_Subtitles_SerialId",
                table: "Subtitles");

            migrationBuilder.DropColumn(
                name: "SerialId",
                table: "Subtitles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialId",
                table: "Subtitles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subtitles_SerialId",
                table: "Subtitles",
                column: "SerialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtitles_Serials_SerialId",
                table: "Subtitles",
                column: "SerialId",
                principalTable: "Serials",
                principalColumn: "Id");
        }
    }
}
