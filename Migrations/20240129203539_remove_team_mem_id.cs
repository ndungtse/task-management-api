using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_management_api.Migrations
{
    /// <inheritdoc />
    public partial class remove_team_mem_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "assignedTeamMemberId",
                table: "Tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_assignedTeamMemberId",
                table: "Tasks",
                column: "assignedTeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TeamMembers_assignedTeamMemberId",
                table: "Tasks",
                column: "assignedTeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "id");
        }
    }
}
