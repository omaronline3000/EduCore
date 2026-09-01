using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class CorrectCourseDepartmentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_departments_departmentId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_departmentId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "courses");

            migrationBuilder.CreateIndex(
                name: "IX_courses_deptId",
                table: "courses",
                column: "deptId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_departments_deptId",
                table: "courses",
                column: "deptId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_departments_deptId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_deptId",
                table: "courses");

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_courses_departmentId",
                table: "courses",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_departments_departmentId",
                table: "courses",
                column: "departmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
