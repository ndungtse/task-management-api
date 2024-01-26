using System.ComponentModel.DataAnnotations;

namespace task_management_api.Dtos.Requests;

public class CreateTeamDto
{
    [Required]
    public string Name { get; set; } = default!;
    
    public string Description { get; set; } = default!;
    
}