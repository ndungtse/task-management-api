using System.ComponentModel.DataAnnotations;

namespace task_management_api.Dtos.Requests;

public class CreateRoleDto
{
    [Required]
    public string RoleName { get; set; }

    public string Code { get; set; }
}