using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCore.Migrations
{
    /// <inheritdoc />
    public partial class LinkTraineeWithUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_trainees_UserId",
                table: "trainees");

            migrationBuilder.CreateIndex(
                name: "IX_trainees_UserId",
                table: "trainees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_trainees_UserId",
                table: "trainees");

            migrationBuilder.CreateIndex(
                name: "IX_trainees_UserId",
                table: "trainees",
                column: "UserId");
        }
    }
}
