using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ItransitionCourseProject.Models
{
    public class UserDestroyerMiddleware
    {
        private readonly RequestDelegate _next;

        public UserDestroyerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            if (!string.IsNullOrEmpty(httpContext.User.Identity?.Name))
            {
                await SignOut(httpContext, userManager, signInManager);
            }

            await _next(httpContext);
        }

        private async Task SignOut(HttpContext httpContext, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            var user = await userManager.FindByNameAsync(httpContext.User.Identity?.Name);
            if (user != null)
            {
                if (user.LockoutEnd > DateTimeOffset.Now)
                {
                    await signInManager.SignOutAsync();
                    httpContext.Response.Redirect("/Account/Login");
                }
            }
            else
            {
                await signInManager.SignOutAsync();
                httpContext.Response.Redirect("/Account/Register");
            }
            await _next(httpContext);
        }
    }

    public static class UserDestroyerMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserDestroyer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserDestroyerMiddleware>();
        }
    }
}