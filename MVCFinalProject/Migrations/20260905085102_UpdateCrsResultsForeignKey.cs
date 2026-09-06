using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCrsResultsForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_courses_courseId",
                table: "crsResults");

            migrationBuilder.DropIndex(
                name: "IX_crsResults_courseId",
                table: "crsResults");

            migrationBuilder.DropColumn(
                name: "courseId",
                table: "crsResults");

            migrationBuilder.CreateIndex(
                name: "IX_crsResults_crsId",
                table: "crsResults",
                column: "crsId");

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_courses_crsId",
                table: "crsResults",
                column: "crsId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_courses_crsId",
                table: "crsResults");

            migrationBuilder.DropIndex(
                name: "IX_crsResults_crsId",
                table: "crsResults");

            migrationBuilder.AddColumn<int>(
                name: "courseId",
                table: "crsResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_crsResults_courseId",
                table: "crsResults",
                column: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_courses_courseId",
                table: "crsResults",
                column: "courseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
