using WebApplication7.IRepository;

namespace WebApplication7.Models
{
    public class BookModel:IBooks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
