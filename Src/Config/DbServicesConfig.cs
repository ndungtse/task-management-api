using Microsoft.EntityFrameworkCore;

namespace task_management_api.Config;

public static class DbServicesConfig
{
    public static void configure(WebApplicationBuilder builder)
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
    }
}