using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using task_management_api.Config;
using task_management_api.Dtos.Requests;
using task_management_api.Modals;

namespace task_management_api.Services;

public class TeamService
{
    private readonly TaskDbContext _taskDb;
    private readonly AuthService _authService;

    public TeamService(TaskDbContext context, AuthService authService)
    {
        _taskDb = context;
        _authService = authService;
    }
    
    public async Task<List<Team>> GetTeams()
    {
        Console.WriteLine("Current Time: " + DateTime.UtcNow);
        return await _taskDb.Teams.ToListAsync();
    }
    
    public async Task<Team> CreateTeam(CreateTeamDto createTeamDto)
    {
        var user = await _authService.getUserFromHeader();
        var team = new Team
        {
            Name = createTeamDto.Name,
            Description = createTeamDto.Description,
            CreatedBy = user
        };
        _taskDb.Teams.Add(team);
        await _taskDb.SaveChangesAsync();
        return team;
    }
    
    public async Task<Team> GetTeam(Guid id)
    {
        var team = await _taskDb.Teams.FindAsync(id);
        if (team == null)
        {
            throw new Exception("Team not found");
        }
        return team;
    }
    
    public async Task<Team> UpdateTeam(CreateTeamDto team, Guid id)
    {
        var teamToUpdate = await _taskDb.Teams.FindAsync(id);
        if (teamToUpdate == null)
        {
            throw new Exception("Team not found");
        }
        teamToUpdate.Name = team.Name;
        teamToUpdate.Description = team.Description;
        await _taskDb.SaveChangesAsync();
        return teamToUpdate;
    }
    
    public async Task DeleteTeam(Guid id)
    {
        var team = await _taskDb.Teams.FindAsync(id);
        if (team == null)
        {
            throw new Exception("Team not found");
        }
        _taskDb.Teams.Remove(team);
        await _taskDb.SaveChangesAsync();
    }
    
    public async Task<List<TeamMember>> GetTeamMembers(Guid id)
    {
        var team = await _taskDb.Teams.FindAsync(id);
        var teamMembers = await _taskDb.TeamMembers.Where(u => u.TeamId == team.Id).ToListAsync();
        return teamMembers;
    }
    
    // team projects
    public async Task<List<Project>> GetTeamProjects(Guid id)
    {
        var team = await _taskDb.Teams.FindAsync(id);
        var projects = await _taskDb.Projects.Where(p => p.TeamId == team.Id).ToListAsync();
        return projects;
    }
}