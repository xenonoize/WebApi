using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebApi.DAL;
using WebApi.DAL.Entities;

namespace WebApi.Util
{
    public static class DatabaseInitializer
    {
        public static async Task Seed(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                try
                {
                    string[] userRoles = User.Roles;
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    foreach (var role in userRoles)
                    {
                        var identityRole = new IdentityRole(role);
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(identityRole);
                        }
                    }
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }


                #region Users
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                var user = await userManager.FindByNameAsync("pimvanenk@gmail.com");

                if (user == null)
                {
                    var email = "pimvanenk@gmail.com";
                    var userToInsert = new User
                    {
                        Email = email,
                        UserName = email,
                        EmailConfirmed = true,
                        //Person = new Person
                        //{
                        //    LastName = "Enk",
                        //    MiddleName = "van",
                        //    FirstName = "Pim",
                        //    Birthdate = new DateTime(1993, 10, 16),
                        //    Initials = "P."

                        //},

                        Id = "07e35556-54f2-4975-a563-417eb5fbfa7d"
                    };
                    var result = await userManager.CreateAsync(userToInsert, "Pim12345!");

                    //Add roles
                    await userManager.AddToRoleAsync(await userManager.FindByNameAsync(email), "Super Administrator");
                }

                await dbContext.SaveChangesAsync();
                #endregion
            }

        }
    }
}
