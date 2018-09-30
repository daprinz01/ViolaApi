using BusinessLogicLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViolaApi.DLL;

namespace ViolaApi.Migrations
{
    public class DbIntializer : IDbInitializer
    {
        IServiceProvider serviceProvider;
        RoleManager<ViolaRoles> roleManager;
        UserManager<ViolaUser> userManager;

        public DbIntializer(IServiceProvider service, RoleManager<ViolaRoles> role, UserManager<ViolaUser> manager)
        {
            serviceProvider = service;
            roleManager = role;
            userManager = manager;
        }
        public async void Initialize()
        {
            ViolaDbContext context = serviceProvider.GetService<ViolaDbContext>();
            await CreateRoleAsync();
            await context.Database.MigrateAsync();
            
        }

        public async Task CreateRoleAsync()
        {
             
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new ViolaRoles());
                }
            }

            var superUser = new ViolaUser
            {
                FirstName = "Okechukwu",
                LastName = "Prince",
                Address = "161A Sinari Daranijo off Ligali Ayorinde",
                City = "Victoria Island",
                State = "Lagos",
                Country = "Nigeria"
            };
            var superPwd = "Princess4Daprinz";
            var user = await userManager.CreateAsync(superUser, superPwd);
            if (user.Succeeded)
            {
                await userManager.AddToRoleAsync(superUser, "Admin");

            }
        }

        
    }
    
}
