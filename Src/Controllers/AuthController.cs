using Microsoft.AspNetCore.Mvc;
using task_management_api.Dtos.Requests;
using task_management_api.Dtos.Responses;
using task_management_api.Services;

namespace task_management_api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController: ControllerBase
{
    private readonly AuthService _authService;
    
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var user = await _authService.Login(loginDto);
            return Ok(new Response<dynamic>(user, "User logged in successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
}