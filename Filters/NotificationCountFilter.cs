using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BookStoreApplication.Repository;

namespace BookStoreApplication.Filters
{
    public class NotificationCountFilter:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Resolve IBookRepository from the request services
            var bookRepository = context.HttpContext.RequestServices.GetService<IBookRepository>();

            if (context.Controller is Controller controller && bookRepository != null)
            {
                controller.ViewBag.NotificationCount = bookRepository.GetLanguageCount();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed after execution
        }
    }
}
