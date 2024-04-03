using BookReadEvent.Models.AccountModel;
using Microsoft.AspNetCore.Identity;

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Repository
{
    public class AccountRepository : IAccountRepository
    {
        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> createuser(RegisterModel model)
        {
            var user = new ApplicationUser() { Email = model.Email ,UserName=model.Email,FirstName=model.FirstName,LastName=model.LastName};
            var result=await userManager.CreateAsync(user, model.password);
            return result;
        }

        public async Task<SignInResult> passwordSignin(LoginModel model)
        {
           var result = await signInManager.PasswordSignInAsync(model.Email, model.password, model.rememberme, false);
            return result;
        }
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

    }
}
