using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using task_management_api.Dtos.Requests;
using task_management_api.Dtos.Responses;
using task_management_api.Modals;
using task_management_api.Services;

namespace task_management_api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var users = await _userService.GetUsers();
            return Ok(new Response<List<User>>(users, "Users retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
    {
        try
        {
            var createdUser = await _userService.CreateUser(user);
            return Ok(new Response<User>(createdUser, "User created successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        try
        {
            var user = await _userService.GetUser(id);
            return Ok(new Response<User>(user, "User retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, CreateUserDto user)
    {
        try
        {
           var updatedUser = await _userService.UpdateUser(user, id);
            return Ok(new Response<User>(updatedUser, "User updated successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        try
        {
            await _userService.DeleteUser(id);
            return Ok(new Response<string>("User deleted successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
}