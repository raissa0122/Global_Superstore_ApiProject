using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using Models.Models;

namespace Books_Web_Api_Final_Project
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedIdentityAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            // Seed roles
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role
                {
                    Name = "user",
                });

                await roleManager.CreateAsync(new Role
                {
                    Name = "admin",
                });
            }

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            // Seed admin

            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "admin",
                };

                var result = await userManager.CreateAsync(user, "123456");

                await userManager.AddToRoleAsync(user, "admin");
            }
        }
    }
}
