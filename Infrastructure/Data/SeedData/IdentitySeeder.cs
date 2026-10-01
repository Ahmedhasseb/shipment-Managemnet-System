using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using model;

namespace Infrastructure.Data.SeedData
{
    public static class IdentitySeeder
    {
        public static async Task SeedRoleAsync(
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            string email = "ahmed233@gmail.com";
            string password = "0123456@As";

            string[] roleNames =
            {
            "Admin",
            "Manager",
            "Employee",
            "Merchant",
            "MerchantEmployee",
            "Driver",
            "User"
        };

            // Seed Roles
            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await roleManager.CreateAsync(
                        new IdentityRole(role));

                    if (!roleResult.Succeeded)
                    {
                        throw new Exception(
                            string.Join(", ",
                                roleResult.Errors.Select(e => e.Description)));
                    }
                }
            }

            // Seed Admin
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Admin",
                    LastName = "System",
                    AccountTypes = AccountTypes.AccountActive,
                    EmailConfirmed = true
                };

                var userResult = await userManager.CreateAsync(user, password);

                if (!userResult.Succeeded)
                {
                    throw new Exception(
                        string.Join(", ",
                            userResult.Errors.Select(e => e.Description)));
                }
            }

            // Add Admin Role
            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                var roleResult = await userManager.AddToRoleAsync(user, "Admin");

                if (!roleResult.Succeeded)
                {
                    throw new Exception(
                        string.Join(", ",
                            roleResult.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
