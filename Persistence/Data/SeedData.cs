using Domain.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        var roleExists = await roleManager.RoleExistsAsync("Admin");
        if (!roleExists)
        {
            var role = new ApplicationRole("Admin");
            await roleManager.CreateAsync(role);
        }

        var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminUser == null)
        {
            var user = new ApplicationUser("Admin", "Admin", "admin@admin.com", "admin");

            var result = await userManager.CreateAsync(user, "Test*123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}