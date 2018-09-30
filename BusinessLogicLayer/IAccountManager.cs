using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using ViolaApi.DLL;

namespace ViolaApi.Services
{
    interface IAccountManager
    {
        Task<IdentityResult> Register(RegisterViewModel model);
        Task<IdentityResult> Login(LoginViewModel model);
        Task<bool> CheckIfUserExists(string param);
        Task<ViolaUser> GetUser(string param, string provider = null);
        
    }
}
