using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id==id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title , string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Author="Deepak", Title = "Ramayan"},
                new BookModel(){Id=2,Author="Deepak", Title = "Ramayan"},
                new BookModel(){Id=3,Author="Deepak", Title = "Ramayan"},
                new BookModel(){Id=4,Author="Deepak", Title = "Ramayan"},
                new BookModel(){Id=5,Author="Deepak", Title = "Ramayan"},


            };
        }
    }
}
