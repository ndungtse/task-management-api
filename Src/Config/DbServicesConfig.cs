using Microsoft.EntityFrameworkCore;
using task_management_api.Services;

namespace task_management_api.Config;

public static class DbServicesConfig
{
    public static void Configure(WebApplicationBuilder builder)
    {
        // Add DbContext
        builder.Services.AddEntityFrameworkNpgsql().AddDbContext<TaskDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add migration and update logic
        using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<TaskDbContext>();

            dbContext.Database.Migrate();
        }
        
        // Add services
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<TeamService>();
        builder.Services.AddScoped<ProjectService>();
        builder.Services.AddScoped<TeamMemberService>();
        builder.Services.AddScoped<TodoService>();
        builder.Services.AddScoped<RoleService>();
    }
}