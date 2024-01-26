using Swashbuckle.AspNetCore.SwaggerUI;
using task_management_api.Config;
using task_management_api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// configure database
DbServicesConfig.Configure(builder);
AuthConfig.Configure(builder);
SwaggerConfig.Configure(builder);
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<JwtAuthenticationMiddleware>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocExpansion(DocExpansion.None);
});
app.UseAuthorization();
app.UseAuthentication();
// app.UseRouting();
app.UseMiddleware<JwtAuthenticationMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
