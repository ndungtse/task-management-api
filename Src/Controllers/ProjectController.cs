using Microsoft.AspNetCore.Mvc;
using task_management_api.Dtos.Requests;
using task_management_api.Dtos.Responses;
using task_management_api.Modals;
using task_management_api.Services;

namespace task_management_api.Controllers;

[ApiController]
[Route("api/v1/projects")]
public class ProjectController: ControllerBase
{
    private readonly ProjectService _projectService;
    
    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        try
        {
            var projects = await _projectService.GetProjects();
            return Ok(new Response<List<Project>>(projects, "Projects retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto project)
    {
        try
        {
            var createdProject = await _projectService.CreateProject(project);
            return Ok(new Response<Project>(createdProject, "Project created successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(Guid id)
    {
        try
        {
            var project = await _projectService.GetProject(id);
            return Ok(new Response<Project>(project, "Project retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject([FromBody] CreateProjectDto project, Guid id)
    {
        try
        {
            var updatedProject = await _projectService.UpdateProject(project, id);
            return Ok(new Response<Project>(updatedProject, "Project updated successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        try
        {
            await _projectService.DeleteProject(id);
            return Ok(new Response<string>("Project deleted successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
}