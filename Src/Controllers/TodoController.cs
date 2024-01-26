using Microsoft.AspNetCore.Mvc;
using task_management_api.Dtos.Requests;
using task_management_api.Dtos.Responses;
using task_management_api.Modals;
using task_management_api.Services;

namespace task_management_api.Controllers;

[ApiController]
[Route("api/v1/tasks")]
public class TodoController: ControllerBase
{
    private readonly TodoService _todoService;
    
    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        try
        {
            var todos = await _todoService.GetTodos();
            return Ok(new Response<List<ToDo>>(todos, "Todos retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDto todo)
    {
        try
        {
            var createdTodo = await _todoService.CreateTodo(todo);
            return Ok(new Response<ToDo>(createdTodo, "Todo created successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodo(Guid id)
    {
        try
        {
            var todo = await _todoService.GetTodoById(id);
            return Ok(new Response<ToDo>(todo, "Todo retrieved successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] CreateTodoDto todo)
    {
        try
        {
            var updatedTodo = await _todoService.UpdateTodoById(todo, id);
            return Ok(new Response<ToDo>(updatedTodo, "Todo updated successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoById(Guid id)
    {
        try
        {
            await _todoService.DeleteTodoById(id);
            return Ok(new Response<string>("Todo deleted successfully", true));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<string>(ex.Message, false));
        }
    }
}