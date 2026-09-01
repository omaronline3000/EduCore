using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class addingIsDeletedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "trainees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "instructors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "crsResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "trainees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "crsResults");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "courses");
        }
    }
}
