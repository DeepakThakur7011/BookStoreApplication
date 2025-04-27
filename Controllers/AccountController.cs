using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using WebApplication7.Models;
using WebApplication7.Repository;
using WebApplication7.Services;

namespace WebApplication7.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IBookRepository bookRepository, ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment, IUserService userService,
            IAccountRepository accountRepository)
            : base(bookRepository, languageRepository, webHostEnvironment, userService, accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel signUpUserModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(signUpUserModel);
                if (!result.Succeeded)
                {
                    foreach (var errormessage in result.Errors)
                    {
                        ModelState.AddModelError("", errormessage.Description);
                    }
                    return View(signUpUserModel);
                }
                ModelState.Clear();
            }
            return View();
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Not allowed to login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Credentials");
                }
                
            }

            return View(signInModel);
        }
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                    if (result.Succeeded)
                {
                    ViewBag.isSuccess = true;
                    ModelState.Clear();
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
