using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adesso.Project.Persistence.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelOffers_AspNetUsers_UserId",
                table: "TravelOffers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TravelOffers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "TravelOffers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelOffers_AspNetUsers_UserId",
                table: "TravelOffers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelOffers_AspNetUsers_UserId",
                table: "TravelOffers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TravelOffers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TravelOffers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelOffers_AspNetUsers_UserId",
                table: "TravelOffers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
