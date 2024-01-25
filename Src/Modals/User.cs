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
    public string Email { get; set; }

    [Required]
    public string Password { get; set; } 
    public List<TeamMember> TeamMembers { get; set; }
    public List<ToDo> AssignedTasks { get; set; }
    public List<Role> Roles { get; set; }
}