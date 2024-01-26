using System.ComponentModel.DataAnnotations;

namespace task_management_api.Dtos.Requests;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
}