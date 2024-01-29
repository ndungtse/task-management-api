using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace task_management_api.Modals;

public class Team: BaseModel
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    
    public Guid CreatedById { get; set; } // Foreign key
    // Navigation property for users
    public User CreatedBy { get; set; }
    [JsonIgnore]
    public virtual List<TeamMember> TeamMembers { get; set; }
    // Navigation property for projects
    [JsonIgnore]
    public virtual List<Project> Projects { get; set; }
    
}