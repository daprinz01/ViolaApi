using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ViewModels;
using ViolaApi.DLL;

namespace ViolaApi.Services
{
    public class AccountManager : IAccountManager
    {
        UserManager<ViolaUser> userManager;
        IServiceProvider serviceProvider;
        
        public AccountManager(UserManager<ViolaUser> manager, IServiceProvider provider)
        {
            userManager = manager;
            serviceProvider = provider;
        }

        public async Task<ViolaUser> GetUser(string param, string provider = null)
        {
            var Emailuser = await userManager.FindByEmailAsync(param);
            var IdUser = await userManager.FindByIdAsync(param);
            var NameUser = await userManager.FindByNameAsync(param);
            var providerUser = await userManager.FindByLoginAsync(provider, param);
            if (Emailuser.FirstName != null )
            {
                return Emailuser;
            }
            else if(IdUser.FirstName != null)
            {
                return IdUser;
            }
            else if (NameUser.FirstName != null)
            {
                return NameUser;
            }
            else if(providerUser.FirstName != null)
            {
                return providerUser;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CheckIfUserExists(string param)
        {
            var Emailuser = await userManager.FindByEmailAsync(param);
            var IdUser = await userManager.FindByIdAsync(param);
            var NameUser = await userManager.FindByNameAsync(param);
            if (Emailuser.FirstName != null || IdUser.FirstName != null || NameUser.FirstName != null)
            {
                return true;
            }
            else return false;
        }

        public async Task<IdentityResult> Login(LoginViewModel model)
        {
            if ((await CheckIfUserExists(model.Username)))
            {
                var user = await GetUser(model.Username);
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return IdentityResult.Success;
                }
                else
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Error occured while creating user" });
                }
            }
        }


        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
            if ((await CheckIfUserExists(model.UserName)))
            {
                var user = await GetUser(model.UserName);
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return IdentityResult.Success;
                }
                else
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Error occured while creating user" });
                }

            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Description = "User does not exist" });
            }
        }
    }
}
