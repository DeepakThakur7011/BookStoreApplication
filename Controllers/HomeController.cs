using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Repository;
using WebApplication7.Services;

namespace WebApplication7.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        public HomeController(IBookRepository bookRepository, ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment, IUserService userService, IAccountRepository accountRepository)
            : base(bookRepository, languageRepository, webHostEnvironment, userService,accountRepository)
        {
            _userService = userService; // Assign the dependency for local use
        }
        [Route("~/")]
        public ViewResult Index()
        {
            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated(); 
            return View();
        }
        [Route("~/contact-us")]
        public ViewResult ContactUs()
        {
            return View();
        }
        [Route("~/about-us")]
        public ViewResult AboutUs(int id , string name)
        {
            return View();
        }
    }
}
