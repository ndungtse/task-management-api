using System.ComponentModel.DataAnnotations.Schema;
using task_management_api.Enums;

namespace task_management_api.Modals;

public class TeamMember: BaseModel
{
    public Guid Id { get; set; }
    public string Role { get; set; } = EMemberRole.Member.ToString();
    public Guid TeamId { get; set; } // Foreign key
    public Guid UserId { get; set; } // Foreign key
    public User User { get; set; }
    public Team Team { get; set; }
    [InverseProperty("AssignedTo")]
    public virtual HashSet<ToDo> AssignedTasks { get; set; }
}