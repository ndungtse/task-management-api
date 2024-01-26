namespace task_management_api.Modals;

public class TeamMember: BaseModel
{
    public Guid Id { get; set; }
    public string Role { get; set; }
    public Guid TeamId { get; set; } // Foreign key
    public Guid UserId { get; set; } // Foreign key
    public User User { get; set; }
    public Team Team { get; set; }
}