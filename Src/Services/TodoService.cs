using Microsoft.EntityFrameworkCore;
using task_management_api.Config;
using task_management_api.Dtos.Requests;
using task_management_api.Modals;

namespace task_management_api.Services;

public class TodoService
{
    private TaskDbContext _taskDb;
    private AuthService _authService;
    
    public TodoService(TaskDbContext context, AuthService authService)
    {
        _taskDb = context;
        _authService = authService;
    }
    
    public async Task<List<ToDo>> GetTodos()
    {
        return await _taskDb.Tasks.ToListAsync();
    }
    
    public async Task<ToDo> CreateTodo(CreateTodoDto createTodoDto)
    {
        var user = await _authService.getUserFromHeader();
        var todo = new ToDo
        {
            Title = createTodoDto.Title,
            Description = createTodoDto.Description,
            Status = createTodoDto.Status,
            Tags = createTodoDto.Tags,
            CreatedBy = user
        };
        _taskDb.Tasks.Add(todo);
        await _taskDb.SaveChangesAsync();
        return todo;
    }
    
    public async Task<ToDo> GetTodoById(Guid id)
    {
        var todo = await _taskDb.Tasks.FindAsync(id);
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }
        return todo;
    }
    
    public async Task<ToDo> UpdateTodoById(CreateTodoDto todo, Guid id)
    {
        var todoToUpdate = await _taskDb.Tasks.FindAsync(id);
        if (todoToUpdate == null)
        {
            throw new Exception("Todo not found");
        }
        todoToUpdate.Title = todo.Title;
        todoToUpdate.Description = todo.Description;
        todoToUpdate.Status = todo.Status;
        todoToUpdate.Tags = todo.Tags;
        await _taskDb.SaveChangesAsync();
        return todoToUpdate;
    }
    
    public async Task DeleteTodoById(Guid id)
    {
        var todo = await _taskDb.Tasks.FindAsync(id);
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }
        _taskDb.Tasks.Remove(todo);
        await _taskDb.SaveChangesAsync();
    }
    
}