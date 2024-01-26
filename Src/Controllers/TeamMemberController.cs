using Microsoft.AspNetCore.Mvc;
using task_management_api.Dtos.Requests;
using task_management_api.Dtos.Responses;
using task_management_api.Modals;
using task_management_api.Services;

namespace task_management_api.Controllers;

[ApiController]
[Route("api/v1/team_members")]
public class TeamMemberController: ControllerBase
{
    private readonly TeamMemberService _service;
    
    public TeamMemberController(TeamMemberService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTeamMembers()
    {
        try
        {
            var teamMembers = await _service.GetTeamMembers();
            return Ok(new Response<List<TeamMember>>(teamMembers, "Team members retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTeamMember([FromBody] CreateTeamMemberDto teamMember)
    {
        try
        {
            var createdTeamMember = await _service.CreateTeamMember(teamMember);
            return Ok(new Response<TeamMember>(createdTeamMember, "Team member created successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamMember(Guid id)
    {
        try
        {
            var teamMember = await _service.GetTeamMember(id);
            return Ok(new Response<TeamMember>(teamMember, "Team member retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeamMember(Guid id, [FromBody] CreateTeamMemberDto teamMember)
    {
        try
        {
            var updatedTeamMember = await _service.UpdateTeamMember(teamMember, id);
            return Ok(new Response<TeamMember>(updatedTeamMember, "Team member updated successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeamMember(Guid id)
    {
        try
        {
            var deletedTeamMember = await _service.DeleteTeamMember(id);
            return Ok(new Response<TeamMember>(deletedTeamMember, "Team member deleted successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
}