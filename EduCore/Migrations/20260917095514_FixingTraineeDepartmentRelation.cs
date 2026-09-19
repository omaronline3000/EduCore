using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCore.Migrations
{
    /// <inheritdoc />
    public partial class FixingTraineeDepartmentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainees_departments_departmentId",
                table: "trainees");

            migrationBuilder.DropIndex(
                name: "IX_trainees_departmentId",
                table: "trainees");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "trainees");

            migrationBuilder.CreateIndex(
                name: "IX_trainees_deptID",
                table: "trainees",
                column: "deptID");

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_departments_deptID",
                table: "trainees",
                column: "deptID",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainees_departments_deptID",
                table: "trainees");

            migrationBuilder.DropIndex(
                name: "IX_trainees_deptID",
                table: "trainees");

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_trainees_departmentId",
                table: "trainees",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_departments_departmentId",
                table: "trainees",
                column: "departmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
