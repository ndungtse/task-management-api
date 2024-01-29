using System.ComponentModel.DataAnnotations;

namespace task_management_api.Modals;

public class ToDo: BaseModel
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public List<string> Tags { get; set; }
    public string Priority { get; set; }
    public Guid ProjectId { get; set; } // Foreign key
    public Guid AssignedTo { get; set; } // Foreign key
    public User Assignee { get; set; }
    public TeamMember AssignedTeamMember { get; set; }
    public Project Project { get; set; }
    public User CreatedBy { get; set; }
    
}