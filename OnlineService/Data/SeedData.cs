using Microsoft.AspNetCore.Identity;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Создаем роли, если они не существуют
        var roles = new[] { "Admin", "User", "Specialist" };
        foreach (var role in roles)
        {
            if (!roleManager.RoleExistsAsync(role).Result)
            {
                var result = roleManager.CreateAsync(new IdentityRole(role)).Result;
                if (!result.Succeeded)
                {
                    throw new Exception($"Cannot create role {role}");
                }
            }
        }

        // Пример создания администратора
        var adminEmail = "admin@example.com";
        var adminUser = userManager.FindByEmailAsync(adminEmail).Result;
        if (adminUser == null)
        {
            adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
            var createUserResult = userManager.CreateAsync(adminUser, "Admin@123").Result;
            if (createUserResult.Succeeded)
            {
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
            }
        }
    }
}


