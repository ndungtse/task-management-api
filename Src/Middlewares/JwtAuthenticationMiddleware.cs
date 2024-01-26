using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using task_management_api.Dtos.Responses;
using task_management_api.Utils;
using Newtonsoft.Json;

namespace task_management_api.Middlewares;

public class JwtAuthenticationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var whiteList = new List<string> {"/api/v1/auth/login", "/api/v1/auth/register"};
        var nextUrl = context.Request.Path.Value;
        Console.WriteLine("Auth nextUrl " + nextUrl);
        Console.WriteLine("White list " + whiteList.Contains(nextUrl));
        if (whiteList.Contains(nextUrl!))
        {
            await next(context);
            return;
        }
        if (token != null)
        {
            Console.WriteLine("Auth middleware token not null");
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
                // Console.WriteLine("Auth middleware principal" + principal.Claims.ToArray()[1]);      
                context.User = principal;
                await next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Return unauthorized if token validation fails
                var response = new Response<string>("Unauthorized", false);
                context.Response.ContentType = "application/json";
                // await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                context.Response.StatusCode = 401;
                await context.Response.HttpContext.Response.WriteAsJsonAsync(response);
            }
        }
        else
        {
            var response = new Response<string>("Unauthorized", false);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 401;
            await context.Response.HttpContext.Response.WriteAsJsonAsync(response);
            // await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        // await next(context);
    }
}