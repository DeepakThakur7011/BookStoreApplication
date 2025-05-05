using BookStoreApplication.Models;

namespace BookStoreApplication.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}