using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Annotations;
using task_management_api.Dtos.Requests;
using task_management_api.Dtos.Responses;
using task_management_api.Modals;
using task_management_api.Services;

namespace task_management_api.Controllers;

[Route("api/v1/auth")]
[SwaggerTag("Authentication operations"
)]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly UserService _userService;

    public AuthController(AuthService authService, UserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [SwaggerOperation(
        Summary = "Login",
        Description = "Login",
        OperationId = "auth.login",
        Tags = new[] { "Auth" }
    )]
    [AllowAnonymous]
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
            Console.WriteLine($"ex {ex}");
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
    {
        try
        {
            var user = await _userService.CreateUser(createUserDto);
            return Ok(new Response<User>(user, "Registered Successfully", true));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<string>(e.Message, false));
        }
    }
}