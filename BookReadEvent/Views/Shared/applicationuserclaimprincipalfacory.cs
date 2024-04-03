using BookReadEvent.Models.AccountModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookReadEvent.Views.Shared
{
    public class applicationuserclaimprincipalfacory:UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public applicationuserclaimprincipalfacory(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,IOptions<IdentityOptions> options):base(userManager,roleManager,options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity= await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName??""));
            identity.AddClaim(new Claim("LastName", user.LastName??""));
            return identity;
        }
    }
}
