using Microsoft.EntityFrameworkCore;
using task_management_api.Config;
using task_management_api.Dtos.Requests;
using task_management_api.Modals;

namespace task_management_api.Services;

public class UserService
{
    private readonly TaskDbContext _context;

    public UserService(TaskDbContext context)
    {
        _context = context;
    }

    // Get All
    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    // Create
    public async Task<User> CreateUser(CreateUserDto createUserDto)
    {
        var isUsernameTaken = await _context.Users.AnyAsync(u => u.Username == createUserDto.Username);
        if (isUsernameTaken)
        {
            throw new Exception("Username is already taken");
        }

        var isEmailTaken = await _context.Users.AnyAsync(u => u.Email == createUserDto.Email);
        if (isEmailTaken)
        {
            throw new Exception("Email is already taken");
        }

        var user = new User
        {
            Username = createUserDto.Username,
            Email = createUserDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password)
        };
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
    public async Task<User> UpdateUser(CreateUserDto user, Guid id)
    {
        var userToUpdate = await _context.Users.FindAsync(id);
        if (userToUpdate == null)
        {
            throw new Exception("User not found");
        }

        userToUpdate.Username = user.Username;
        userToUpdate.Email = user.Email;
        await _context.SaveChangesAsync();
        return userToUpdate;
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