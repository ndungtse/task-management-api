using Microsoft.AspNetCore.Mvc;
using task_management_api.Dtos.Requests;
using task_management_api.Dtos.Responses;
using task_management_api.Modals;
using task_management_api.Services;

namespace task_management_api.Controllers;

[ApiController]
[Route("api/v1/teams")]
public class TeamController: ControllerBase
{
    private readonly TeamService _teamService;
    
    public TeamController(TeamService teamService)
    {
        _teamService = teamService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        try
        {
            var teams = await _teamService.GetTeams();
            return Ok(new Response<List<Team>>(teams, "Teams retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamDto team)
    {
        try
        {
            var createdTeam = await _teamService.CreateTeam(team);
            return Ok(new Response<Team>(createdTeam, "Team created successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeam(Guid id)
    {
        try
        {
            var team = await _teamService.GetTeam(id);
            return Ok(new Response<Team>(team, "Team retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam( Guid id, CreateTeamDto team)
    {
        try
        {
           var updateTeam = await _teamService.UpdateTeam(team, id);
            return Ok(new Response<Team>(updateTeam, "Team updated successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        try
        {
            await _teamService.DeleteTeam(id);
            return Ok(new Response<string>("Team deleted successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
}