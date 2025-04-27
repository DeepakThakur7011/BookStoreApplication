using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication7.Repository;
using WebApplication7.Services;

namespace WebApplication7.Controllers
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
    }
}
