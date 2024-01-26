namespace task_management_api.Dtos.Requests;

public class CreateTeamMemberDto
{
    public string Role { get; set; }
    public Guid TeamId { get; set; }
    public Guid UserId { get; set; }
}