using Microsoft.EntityFrameworkCore;
using task_management_api.Config;
using task_management_api.Dtos.Requests;
using task_management_api.Modals;

namespace task_management_api.Services;

public class RoleService
{
    private TaskDbContext _taskDb;
    private AuthService _authService;
    
    public RoleService(TaskDbContext context, AuthService authService)
    {
        _taskDb = context;
        _authService = authService;
    }
    
    public async Task<List<Role>> GetRoles()
    {
        return await _taskDb.Roles.ToListAsync();
    }
    
    public async Task<Role> CreateRole(CreateRoleDto createRoleDto)
    {
        var role = new Role
        {
            RoleName = createRoleDto.RoleName,
            Code = createRoleDto.Code
        };
        _taskDb.Roles.Add(role);
        await _taskDb.SaveChangesAsync();
        return role;
    }
    
    public async Task<Role> GetRole(Guid id)
    {
        var role = await _taskDb.Roles.FindAsync(id);
        if (role == null)
        {
            throw new Exception("Role not found");
        }
        return role;
    }
    
    public async Task<Role> UpdateRole(CreateRoleDto role, Guid id)
    {
        var roleToUpdate = await _taskDb.Roles.FindAsync(id);
        if (roleToUpdate == null)
        {
            throw new Exception("Role not found");
        }
        roleToUpdate.RoleName = role.RoleName;
        roleToUpdate.Code = role.Code;
        await _taskDb.SaveChangesAsync();
        return roleToUpdate;
    }
    
    public async Task<Role> DeleteRole(Guid id)
    {
        var roleToDelete = await _taskDb.Roles.FindAsync(id);
        if (roleToDelete == null)
        {
            throw new Exception("Role not found");
        }
        _taskDb.Roles.Remove(roleToDelete);
        await _taskDb.SaveChangesAsync();
        return roleToDelete;
    }
    
}