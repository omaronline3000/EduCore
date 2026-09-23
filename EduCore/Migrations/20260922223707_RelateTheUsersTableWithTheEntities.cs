using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCore.Migrations
{
    /// <inheritdoc />
    public partial class RelateTheUsersTableWithTheEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "trainees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "instructors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainees_UserId",
                table: "trainees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_UserId",
                table: "instructors",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_AspNetUsers_UserId",
                table: "instructors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_AspNetUsers_UserId",
                table: "trainees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_AspNetUsers_UserId",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_trainees_AspNetUsers_UserId",
                table: "trainees");

            migrationBuilder.DropIndex(
                name: "IX_trainees_UserId",
                table: "trainees");

            migrationBuilder.DropIndex(
                name: "IX_instructors_UserId",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "trainees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "instructors");
        }
    }
}
