using Microsoft.EntityFrameworkCore;
using task_management_api.Config;
using task_management_api.Modals;
namespace task_management_api.Services;

public class UserService
{
    private readonly TaskDbContext _context;

    public UserService(TaskDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task<User> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    // Read
    public async Task<User> GetUser(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    // Update
    public async Task UpdateUser(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    // Delete
    public async Task DeleteUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}