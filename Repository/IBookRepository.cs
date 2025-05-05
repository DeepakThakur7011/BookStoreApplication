using Microsoft.AspNetCore.Mvc;
using BookStoreApplication.Models;

namespace BookStoreApplication.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAll();
        Task<BookModel> GetBookById(int id);
        Task<LanguageModel> GetLanguageById(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBook(string title, string authorName);
        string GetAppName();
        Task<int> AddNewLanguage(LanguageModel languageModel);
        Task<List<LanguageModel>> ListAllLanguage(string searchText);
        Task UpdateLanguage(LanguageModel model);
        Task<bool> DeleteLanguage(int id);
        int GetLanguageCount();
    }
}