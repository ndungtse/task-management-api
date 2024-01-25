using System.ComponentModel.DataAnnotations;

namespace task_management_api.Dtos.Requests;

public class CreateUserDto
{   
    [Required]
    public string Username { get; set; } = default!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
    // public List<Guid> TeamIds { get; set; } = new();
    // public List<Guid> RoleIds { get; set; } = new();
}