using Microsoft.AspNetCore.Mvc;
using WebApplication7.Repository;

namespace WebApplication7.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly IBookRepository _bookRepository; 
        public TopBooksViewComponent(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var books = await _bookRepository.GetTopBooksAsync(count);
            return View(books);
        }
    }
}
