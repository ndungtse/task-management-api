using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace task_management_api.Modals;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User: BaseModel
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

    public virtual List<TeamMember> TeamMembers { get; set; }
    public virtual List<ToDo> AssignedTasks { get; set; }
    public List<Role> Roles { get; set; }
    
    // public TeamMember currentTeamMember { get; set; }
    public override string ToString()
    {
        return $"User: {Username}, {Email}";
    }
}