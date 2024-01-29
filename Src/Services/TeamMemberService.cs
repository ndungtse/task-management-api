using Microsoft.EntityFrameworkCore;
using task_management_api.Config;
using task_management_api.Dtos.Requests;
using task_management_api.Modals;

namespace task_management_api.Services;

public class TeamMemberService
{
    private readonly TaskDbContext _taskDb;
    private readonly AuthService _authService;

    public TeamMemberService(TaskDbContext context, AuthService authService)
    {
        _taskDb = context;
        _authService = authService;
    }

    public async Task<List<TeamMember>> GetTeamMembers()
    {
        return await _taskDb.TeamMembers.ToListAsync();
    }

    public async Task<TeamMember> CreateTeamMember(CreateTeamMemberDto teamMember)
    {
        var user = await _authService.getUserFromHeader();
        var teamMemberToCreate = new TeamMember
        {
            Role = teamMember.Role,
            TeamId = teamMember.TeamId,
            UserId = teamMember.UserId,
            User = user
        };
        _taskDb.TeamMembers.Add(teamMemberToCreate);
        await _taskDb.SaveChangesAsync();
        return teamMemberToCreate;
    }

    public async Task<TeamMember> GetTeamMember(Guid id)
    {
        var teamMember = await _taskDb.TeamMembers.FindAsync(id);
        if (teamMember == null)
        {
            throw new Exception("Team member not found");
        }

        return teamMember;
    }

    public async Task<TeamMember> UpdateTeamMember(CreateTeamMemberDto teamMember, Guid id)
    {
        var teamMemberToUpdate = await _taskDb.TeamMembers.FindAsync(id);
        if (teamMemberToUpdate == null)
        {
            throw new Exception("Team member not found");
        }

        teamMemberToUpdate.Role = teamMember.Role;
        teamMemberToUpdate.TeamId = teamMember.TeamId;
        teamMemberToUpdate.UserId = teamMember.UserId;
        await _taskDb.SaveChangesAsync();
        return teamMemberToUpdate;
    }

    public async Task<TeamMember> DeleteTeamMember(Guid id)
    {
        var teamMemberToDelete = await _taskDb.TeamMembers.FindAsync(id);
        if (teamMemberToDelete == null)
        {
            throw new Exception("Team member not found");
        }

        _taskDb.TeamMembers.Remove(teamMemberToDelete);
        await _taskDb.SaveChangesAsync();
        return teamMemberToDelete;
    }

    // Assign task to team member
    public async Task<ToDo> AssignTaskToTeamMember(Guid teamMemberId, Guid taskId)
    {
        var teamMember = await _taskDb.TeamMembers.FindAsync(teamMemberId);
        if (teamMember == null)
        {
            throw new Exception("Team member not found");
        }

        var task = await _taskDb.Tasks.FindAsync(taskId);
        if (task == null)
        {
            throw new Exception("Task not found");
        }

        task.AssignedTo = teamMember.Id;
        await _taskDb.SaveChangesAsync();
        return task;
    }

    // Assign Multiple Tasks to Team Member
    public async Task<List<ToDo>> AssignMultipleTasksMember(Guid teamMemberId, List<Guid> tasks)
    {
        var teamMember = await _taskDb.TeamMembers.FindAsync(teamMemberId);
        if (teamMember == null)
        {
            throw new Exception("Team member not found");
        }

        var assignedTasks = new HashSet<ToDo>();
        foreach (var taskId in tasks)
        {
            var task = await _taskDb.Tasks.FindAsync(taskId);
            if (task == null)
            {
                continue;
            }

            task.AssignedTo = teamMember.Id;
            await _taskDb.SaveChangesAsync();
            assignedTasks.Add(task);
        }

        return assignedTasks.ToList();
    }
}