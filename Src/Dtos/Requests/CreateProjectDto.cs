using System.ComponentModel.DataAnnotations;

namespace task_management_api.Dtos.Requests;

public class CreateProjectDto
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [Required] public Guid TeamId { get; set; }
}
