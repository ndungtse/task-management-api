using task_management_api.Modals;
using Task = task_management_api.Modals.Task; // To avoid conflict with System.Threading.Tasks.Task
namespace task_management_api.Config;

using Microsoft.EntityFrameworkCore;

public class TaskDbContext: DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }
    
    // DbSet for each entity
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    
    // Many-to-Many relationship between User and Role
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // make all table names start with lowercase
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.Name[0].ToString().ToLower() + property.Name.Substring(1));
            }
        }
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRoles",
                ur => ur.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                ur => ur.HasOne<User>().WithMany().HasForeignKey("UserId"),
                ur =>
                {
                    ur.Property("UserId").HasColumnName("UserId");
                    ur.Property("RoleId").HasColumnName("RoleId");
                }
            );
        
        // One-to-Many relationship between Team and TeamMember
        modelBuilder.Entity<Team>()
            .HasMany(t => t.TeamMembers)
            .WithOne(tm => tm.Team)
            .HasForeignKey(tm => tm.TeamId)
            .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.Cascade if you want to cascade deletes

        // One-to-Many relationship between User and TeamMember
        modelBuilder.Entity<User>()
            .HasMany(u => u.TeamMembers)
            .WithOne(tm => tm.User)
            .HasForeignKey(tm => tm.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // One-to-Many relationship between Team and Project
        modelBuilder.Entity<Team>()
            .HasMany(t => t.Projects)
            .WithOne(p => p.Team)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // One-to-Many relationship between Project and Task
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Many-to-One relationship between User and Task (AssignedTo)
        modelBuilder.Entity<Task>()
            .HasOne(t => t.Assignee)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(t => t.AssignedTo)
            .OnDelete(DeleteBehavior.Restrict);
    }
}