using Microsoft.EntityFrameworkCore;
using BookStoreApplication.Data;
using BookStoreApplication.Models;

namespace BookStoreApplication.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _context = null;
        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                LanguageId = x.LanguageId,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
