using System.ComponentModel.DataAnnotations;
using task_management_api.Enums;

namespace task_management_api.Dtos.Requests;

public class CreateTodoDto
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = ETodoStatus.NotStarted.ToString();
    public string Priority = EPriority.Medium.ToString();
    public List<string> Tags { get; set; }
}