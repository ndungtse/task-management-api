using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_management_api.Migrations
{
    /// <inheritdoc />
    public partial class remove_rowversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rowVersion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "rowVersion",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "rowVersion",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "rowVersion",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "rowVersion",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "rowVersion",
                table: "Projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "rowVersion",
                table: "Users",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "rowVersion",
                table: "Teams",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "rowVersion",
                table: "TeamMembers",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "rowVersion",
                table: "Tasks",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "rowVersion",
                table: "Role",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "rowVersion",
                table: "Projects",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
