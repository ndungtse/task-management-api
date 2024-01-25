using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace task_management_api.Modals;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required] 
    [EmailAddress] 
    [MaxLength(256)]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!; 
    public List<TeamMember> TeamMembers { get; set; }
    public List<ToDo> AssignedTasks { get; set; }
    public List<Role> Roles { get; set; }
    
    public override string ToString()
    {
        return $"User: {Username}, {Email}";
    }
}