using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Category = model.Category,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };
            newBook.bookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }        
        public async Task<int> AddNewLanguage(LanguageModel model)
        {
            var newLanguage = new Language()
            {
                Name = model.Name,
                Description = model.Description,
            };
            await _context.Language.AddAsync(newLanguage) ;
            await _context.SaveChangesAsync();
            return newLanguage.LanguageId;

        }
        public async Task<List<BookModel>> GetAll()
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl
            }).ToListAsync();
        }
        public async Task<List<LanguageModel>> ListAllLanguage(string searchText)
        {
            var languages = _context.Language.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                languages = languages.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));
            }

            return await languages
                        .Select(x => new LanguageModel()
                        {
                            LanguageId = x.LanguageId,
                            Name = x.Name,
                            Description = x.Description
                        }).ToListAsync();
        }
        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {

            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl
            }).Take(count).ToListAsync();
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    //LanguageId = book.LanguageId,
                    Langauge=book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL,
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl

                }).FirstOrDefaultAsync();
        }
        public async Task<LanguageModel> GetLanguageById(int id)
        {
            return await _context.Language.Where(x => x.LanguageId == id)
                .Select(language => new LanguageModel()
                {
                    LanguageId=language.LanguageId, 
                    Name=language.Name,
                    Description=language.Description
                }).FirstOrDefaultAsync();
        }
        public async Task UpdateLanguage(LanguageModel model)
        {
            var language = await _context.Language.FindAsync(model.LanguageId);

            if (language != null)
            {
                language.Name = model.Name;
                language.Description = model.Description;

                _context.Language.Update(language);
                await _context.SaveChangesAsync();
            }
        }
        // Delete Language
        public async Task<bool> DeleteLanguage(int id)
        {
            var language = await _context.Language.FindAsync(id);

            if (language == null)
                return false;

            bool hasBooks = await _context.Books.AnyAsync(b => b.LanguageId == id);

            if (hasBooks)
                return false; // Prevent Delete if Books Exists

            _context.Language.Remove(language);
            await _context.SaveChangesAsync();
            return true;
        }
        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }
        public string GetAppName()
        {
            return "Book Store Application";
        }
        public int GetLanguageCount()
        {
            return _context.Language.Count();
        }
    }
}