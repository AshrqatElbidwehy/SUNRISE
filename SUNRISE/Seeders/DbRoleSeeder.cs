using Microsoft.AspNetCore.Identity;
using SUNRISE.Models;

namespace SUNRISE.Seeders
{
    public static class DbRoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider service)
        {
            // Seeds Roles

            // 1- getting the services (API's) responsible for `Users` and `roles` manging
            var userManager = service.GetService<UserManager<ApplicationUserEntity>>();
            var roleManager = service.GetService<RoleManager<ApplicationUserRoleEntity>>();


            var roleChef = await roleManager?.FindByNameAsync("Chef");
            var roleCustomer = await roleManager?.FindByNameAsync("Customer");

            // 2- creating and adding roles to the `roleManger` Instance
            if (roleManager is not null && userManager is not null)
            {
                await roleManager.CreateAsync(new ApplicationUserRoleEntity("Chef"));
                await roleManager.CreateAsync(new ApplicationUserRoleEntity("Customer"));

                // creating admin in code to be secure.

                var userchef = new ApplicationUserEntity
                {
                    UserName = "chef@gmail.com",
                    Email = "chef@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var userCustomer = new ApplicationUserEntity
                {
                    UserName = "customer@gmail.com",
                    Email = "customer@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                // Check for email
                var userInDbChef = await userManager.FindByEmailAsync(userchef.Email);
                var userInDbCustomer = await userManager.FindByEmailAsync(userCustomer.Email);

                // If no user is found with that email (Email = "admin@gmail.com")
                // Then we create an new account and set it as admin.

                // This part ensures that there is always an admin account.
                if (userInDbChef == null)
                {
                    // setting it's password
                    await userManager.CreateAsync(userchef, "Password_1");
                    // setting it's role
                    await userManager.AddToRoleAsync(userchef, "Chef");
                }

                if (userInDbCustomer == null)
                {
                    // setting it's password
                    await userManager.CreateAsync(userCustomer, "Password_1");
                    // setting it's role
                    await userManager.AddToRoleAsync(userCustomer, "Customer");
                }
                /* If the email doesn't exist we will make a new account

                 */
            }
        }
    }
}
