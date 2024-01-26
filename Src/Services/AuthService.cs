using Microsoft.EntityFrameworkCore;
using task_management_api.Config;
using task_management_api.Dtos.Requests;
using task_management_api.Modals;
using task_management_api.Utils;

namespace task_management_api.Services;

public class AuthService
{
    private readonly TaskDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public AuthService(TaskDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<dynamic> Login(LoginDto loginDto)
    {
        Console.WriteLine("=== Login ===");
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        Console.WriteLine("=== User ===" + user?.ToString());
        if (user == null)
        {
            throw new Exception("Email or password is incorrect");
        }
        var isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);
        if (!isPasswordValid)
        {
            throw new Exception("Email or password is incorrect");
        }

        var token = JwtUtils.GenerateJwtToken(user);
        Console.WriteLine("token: " + token);
        return new
        {
            user,
            token
        };
    }
    
    public async Task<User> getUserFromHeader()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault();
        Console.WriteLine($"userIdClaim {userIdClaim}");
        Console.WriteLine($"_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault() {_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault()}");
        if (userIdClaim == null)
        {
            throw new Exception("User not found");
        }
        var user = await _context.Users.FindAsync(Guid.Parse(userIdClaim.Value));
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }
}