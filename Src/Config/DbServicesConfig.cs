using Microsoft.EntityFrameworkCore;
using task_management_api.Services;

namespace task_management_api.Config;

public static class DbServicesConfig
{
    public static void Configure(WebApplicationBuilder builder)
    {
        // Add DbContext
        var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
            ? builder.Configuration.GetConnectionString("DefaultConnection")
            : Environment.GetEnvironmentVariable("DATABASE_URL");
        Console.WriteLine($"DbServicesConfig: DbContext added {connectionString}");
        builder.Services.AddEntityFrameworkNpgsql().AddDbContext<TaskDbContext>(opt =>
            opt.UseNpgsql(connectionString));
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