using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using aspconsoleapp.Models.AccountViewModels;
using System.Threading.Tasks;

namespace aspconsoleapp.Controllers
{
    [Authorize]      // This enables that protaction that only Authorize/login user can enter  into the AccountClass Controller.
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;
        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signManager = signInManager;

        }

       [AllowAnonymous]     // This enables user to accress this controller to register-page:
       public IActionResult Register()
       {
           return View();
       }

        [AllowAnonymous] 
        [HttpPost]
        [ValidateAntiForgeryToken] //
        public async Task<IActionResult> Register(RegsiterViewModel regsiterViewModel)
        {
            if(ModelState.IsValid){
                 var user = new IdentityUser { UserName = regsiterViewModel.EmailAddress, Email= regsiterViewModel.EmailAddress};
                 var result = await _userManager.CreateAsync(user, regsiterViewModel.Password);
                 if(result.Succeeded)
                 {
                     await _signManager.SignInAsync(user, false);
                     
                    return  RedirectToAction(nameof(ContactController.List),"Contact");
                 }
                 foreach(var error in result.Errors)
                 {
                     ModelState.AddModelError(string.Empty, error.Description);
                 }
                  
            }
            return View(regsiterViewModel);
        }       

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(loginViewModel.EmailAddress, loginViewModel.Password, false, false);
                
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(ContactController.List),"Contact");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login attempt");  
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}