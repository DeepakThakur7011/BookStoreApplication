using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
       public ViewResult Index()
        {
            return View();
        }
    }
}
