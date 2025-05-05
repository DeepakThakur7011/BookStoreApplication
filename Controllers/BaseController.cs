using Microsoft.AspNetCore.Mvc;
using BookStoreApplication.Repository;
using BookStoreApplication.Services;

namespace BookStoreApplication.Controllers
{
    public class BaseController : Controller
    {
        protected static readonly List<string> AllLanguages = new()
        {
            "Hindi", "English", "Math", "Science", "History", "Geography"
        };
        protected readonly IBookRepository _bookRepository;
        protected readonly ILanguageRepository _languageRepository;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IUserService _userService;
        private readonly IAccountRepository _accountRepository;

        public BaseController(IBookRepository bookRepository, ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment, IUserService userService,
            IAccountRepository accountRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
            _accountRepository = accountRepository;
        }
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    ViewBag.NotificationCount = _bookRepository.GetLanguageCount(); // Set notification count
        //    base.OnActionExecuting(context);
        //}
    }
}
