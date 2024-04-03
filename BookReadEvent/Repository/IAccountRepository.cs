using BookReadEvent.Models.AccountModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookReadEvent.Repository
{
    public interface IAccountRepository
    {
         Task<IdentityResult> createuser(RegisterModel model);
         Task<SignInResult> passwordSignin(LoginModel model);
        Task Logout();
    }
}