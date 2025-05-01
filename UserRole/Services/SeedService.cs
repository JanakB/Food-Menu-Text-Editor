using Microsoft.AspNetCore.Identity;
using UserRole.Data;
using UserRole.Models;

namespace UserRole.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Users>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                //Enter the database is ready
                logger.LogInformation("Ensuring the database is created");
                await context.Database.EnsureCreatedAsync();

                //Add Role
                logger.LogInformation("Seeding roles.");
                await AddRoleAsync(roleManger, "Admin");
                await AddRoleAsync(roleManger, "user");

                //Add admin user
                logger.LogInformation("seeding admin user.");
                var adminEmail = "admin@codehub.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new Users
                    {
                        FullName = "Code hub",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Admin role to the admin user.");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occured while seeding the database.");
            }
        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManger, string roleName)
        {
            if (!await roleManger.RoleExistsAsync(roleName))
            {
                var result = await roleManger .CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}':{string.Join(",", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
