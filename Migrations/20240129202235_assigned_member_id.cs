using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_management_api.Migrations
{
    /// <inheritdoc />
    public partial class assigned_member_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "assignedTeamMemberId",
                table: "Tasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_assignedTeamMemberId",
                table: "Tasks",
                column: "assignedTeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TeamMembers_assignedTeamMemberId",
                table: "Tasks",
                column: "assignedTeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TeamMembers_assignedTeamMemberId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_assignedTeamMemberId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "assignedTeamMemberId",
                table: "Tasks");
        }
    }
}
