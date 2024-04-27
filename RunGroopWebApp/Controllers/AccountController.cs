using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Data;
using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;

namespace RunGroopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUserModel> _userManager;
        private readonly SignInManager<AppUserModel> _signInManager;
        public readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUserModel> userManager,
                                 SignInManager<AppUserModel> signInManager,
                                 ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (user != null)
            {
                //usuário encontrado. Verificar senha
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                
                if (passwordCheck)
                {
                    //senha correta. Login
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded) 
                    {
                        return RedirectToAction("Index", "Race");
                    }
                }
                //senha incorreta
                TempData["Error"] = "Wrong credentials, Please, try again";
                return View(loginViewModel);
            }
            //usuário não encontrado
            TempData["Error"] = "Wrong credentials, Please, try again";
            return View(loginViewModel);
        }
    }
}
