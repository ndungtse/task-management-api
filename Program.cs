using task_management_api.Config;
using task_management_api.Middlewares;
using task_management_api.Services;

var builder = WebApplication.CreateBuilder(args);

// configure database
DbServicesConfig.Configure(builder);
AuthConfig.Configure(builder);
SwaggerConfig.Configure(builder);
builder.Services.AddControllers();
builder.Services.AddScoped<JwtAuthenticationMiddleware>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.UseAuthentication();
// app.UseRouting();
app.UseMiddleware<JwtAuthenticationMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
