using BookReadEvent.Models.AccountModel;
using BookReadEvent.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository repo;

        public AccountController(IAccountRepository repo)
        {
            this.repo = repo;
        }
        [Route("signup")]
        public IActionResult signup()
        {
            return View();
        }
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> signup(RegisterModel model)    
        {
            if(ModelState.IsValid)
            {
                //code
                var result = await repo.createuser(model);
                if(!result.Succeeded)
                {
                    foreach(var msg in result.Errors)
                    {
                        ModelState.AddModelError("",msg.Description);
                    }
                    return View(model);
                }
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
               var result= await repo.passwordSignin(model);
                if(result.Succeeded)
                {   if (!string.IsNullOrEmpty(returnUrl))
                        return LocalRedirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await repo.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
