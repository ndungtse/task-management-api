using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using task_management_api.Utils;

namespace task_management_api.Middlewares;

public class JwtAuthenticationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        Console.WriteLine("Auth token" + token);
        if (token != null)
        {
            Console.WriteLine("Auth midd token not null");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtUtils.secret));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
                // Console.WriteLine("Auth midd principal" + principal.Claims.ToArray()[1]);      
                context.User = principal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Return unauthorized if token validation fails
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
            }
        }
        else
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
        }

        await next(context);
    }
}