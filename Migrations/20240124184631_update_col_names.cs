using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_management_api.Migrations
{
    /// <inheritdoc />
    public partial class update_col_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssignedTo",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Users_UserId",
                table: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "Users",
                newName: "IX_Users_username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "Users",
                newName: "IX_Users_email");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teams",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Teams",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Teams",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TeamMembers",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamMembers",
                newName: "teamId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "TeamMembers",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TeamMembers",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_userId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_teamId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "Tasks",
                newName: "tags");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Tasks",
                newName: "projectId");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Tasks",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tasks",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "AssignedTo",
                table: "Tasks",
                newName: "assignedTo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tasks",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                newName: "IX_Tasks_projectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignedTo",
                table: "Tasks",
                newName: "IX_Tasks_assignedTo");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Role",
                newName: "roleName");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Role",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Role",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Projects",
                newName: "teamId");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Projects",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Projects",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                newName: "IX_Projects_teamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_teamId",
                table: "Projects",
                column: "teamId",
                principalTable: "Teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_projectId",
                table: "Tasks",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_assignedTo",
                table: "Tasks",
                column: "assignedTo",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_teamId",
                table: "TeamMembers",
                column: "teamId",
                principalTable: "Teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Users_userId",
                table: "TeamMembers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_teamId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_projectId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_assignedTo",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_teamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Users_userId",
                table: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_username",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Teams",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Teams",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Teams",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Teams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "TeamMembers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "teamId",
                table: "TeamMembers",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "TeamMembers",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TeamMembers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_userId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_teamId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_TeamId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Tasks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "tags",
                table: "Tasks",
                newName: "Tags");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "projectId",
                table: "Tasks",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "Tasks",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Tasks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "assignedTo",
                table: "Tasks",
                newName: "AssignedTo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tasks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_projectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_assignedTo",
                table: "Tasks",
                newName: "IX_Tasks_AssignedTo");

            migrationBuilder.RenameColumn(
                name: "roleName",
                table: "Role",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Role",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Role",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "teamId",
                table: "Projects",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Projects",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Projects",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Projects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_teamId",
                table: "Projects",
                newName: "IX_Projects_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssignedTo",
                table: "Tasks",
                column: "AssignedTo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Users_UserId",
                table: "TeamMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
