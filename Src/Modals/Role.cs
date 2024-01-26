namespace task_management_api.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Role: BaseModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string RoleName { get; set; }

    public string Code { get; set; }

    // Many-to-Many relationship with User
    public List<User> Users { get; set; } = new List<User>();

    public Role(string roleName)
    {
        RoleName = roleName;
    }
}
