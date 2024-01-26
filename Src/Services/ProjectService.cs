using Microsoft.EntityFrameworkCore;
using task_management_api.Config;
using task_management_api.Dtos.Requests;
using task_management_api.Modals;

namespace task_management_api.Services;

public class ProjectService
{
    private readonly TaskDbContext _taskDb;
    private readonly AuthService _authService;
    
    public ProjectService(TaskDbContext context, AuthService authService)
    {
        _taskDb = context;
        _authService = authService;
    }
    
    public async Task<List<Project>> GetProjects()
    {
        return await _taskDb.Projects.ToListAsync();
    }
    
    public async Task<Project> CreateProject(CreateProjectDto project)
    {
        var user = await _authService.getUserFromHeader();
        var projectToCreate = new Project
        {
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            CreatedBy = user
        };
        _taskDb.Projects.Add(projectToCreate);
        await _taskDb.SaveChangesAsync();
        return projectToCreate;
    }
    
    public async Task<Project> GetProject(Guid id)
    {
        var project = await _taskDb.Projects.FindAsync(id);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        return project;
    }
    
    public async Task<Project> UpdateProject(CreateProjectDto project, Guid id)
    {
        var projectToUpdate = await _taskDb.Projects.FindAsync(id);
        if (projectToUpdate == null)
        {
            throw new Exception("Project not found");
        }
        projectToUpdate.Name = project.Name;
        projectToUpdate.Description = project.Description;
        projectToUpdate.StartDate = project.StartDate;
        projectToUpdate.EndDate = project.EndDate;
        await _taskDb.SaveChangesAsync();
        return projectToUpdate;
    }
    
    public async Task DeleteProject(Guid id)
    {
        var project = await _taskDb.Projects.FindAsync(id);
        if (project == null)
        {
            throw new Exception("Project not found");
        }
        _taskDb.Projects.Remove(project);
        await _taskDb.SaveChangesAsync();
    }
}