using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelatoins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_courseId",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_departments_departmentId",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_instructors_courseId",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_instructors_departmentId",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "courseId",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "instructors");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_crsId",
                table: "instructors",
                column: "crsId");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_deptId",
                table: "instructors",
                column: "deptId");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_crsId",
                table: "instructors",
                column: "crsId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_departments_deptId",
                table: "instructors",
                column: "deptId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_crsId",
                table: "instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_instructors_departments_deptId",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_instructors_crsId",
                table: "instructors");

            migrationBuilder.DropIndex(
                name: "IX_instructors_deptId",
                table: "instructors");

            migrationBuilder.AddColumn<int>(
                name: "courseId",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_instructors_courseId",
                table: "instructors",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_departmentId",
                table: "instructors",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_courseId",
                table: "instructors",
                column: "courseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_departments_departmentId",
                table: "instructors",
                column: "departmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
