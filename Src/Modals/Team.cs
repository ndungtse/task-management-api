using System.ComponentModel.DataAnnotations;

namespace task_management_api.Modals;

public class Team: BaseModel
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    
    public User CreatedBy { get; set; } // UserId of the creator

    // Navigation property for team members
    public List<TeamMember> TeamMembers { get; set; }

    // Navigation property for projects
    public List<Project> Projects { get; set; }
}