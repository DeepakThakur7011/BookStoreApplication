using WebApplication7.Models;

namespace WebApplication7.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}