using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using BookStoreApplication.Models;
using BookStoreApplication.Repository;
using BookStoreApplication.Services;
using BookStoreApplication.Controllers;

namespace BookStoreApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : BaseController
    {
        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment, IUserService userService,
            IAccountRepository accountRepository)
            : base(bookRepository, languageRepository, webHostEnvironment, userService, accountRepository)
        {

        }
        [Route("~/all-books")]
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAll();
            return View(data);
        }
        public async Task<IActionResult> GetAllLanguage()
        {
            var languages = await _bookRepository.ListAllLanguage("");
            return View(languages);
        }
        public async Task<IActionResult> SearchLanguage(string searchText)
        {
            var languages = await _bookRepository.ListAllLanguage(searchText);
            if (!string.IsNullOrEmpty(searchText))
            {
                languages = languages.Where(x => x.Name.ToLower().Contains(searchText.ToLower())).ToList();

            }   
                return PartialView("_languageThumbnail", languages);
        }

        [Route("~/book-deatalis/{id}" , Name ="BookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> Search(string bookName , string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
               
        }
        [HttpGet]
        [Authorize]
        public async Task<ViewResult> AddNewBook(bool isSuccess = false , int bookId=0)
        {     
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;

            return View();
        }        
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if(ModelState.IsValid) 
            {
                if(bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";

                    bookModel.CoverImageUrl = await UploadImage(folder , bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();

                    foreach(var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL= await UploadImage(folder, file)
                        };
                        bookModel.Gallery.Add(gallery);
                    }
                    
                }

                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf/";

                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }

                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }    
            return View();
        }
        // GET Method
        [HttpGet]
        public async Task<ViewResult> AddNewLanguage(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        // POST Method
        [HttpPost]
        public async Task<IActionResult> AddNewLanguage(LanguageModel languageModel)
        {
            if (ModelState.IsValid)
            {
                // Call the repository to add the language to the database
                int id = await _bookRepository.AddNewLanguage(languageModel);

                if (id > 0)
                {
                    // Return a JSON response indicating success
                    return Json(new { success = true, message = "Language added successfully!" });
                }
                else
                {
                    // Return a failure message if the language wasn't added
                    return Json(new { success = false, message = "Failed to add language." });
                }
            }

            // Return a failure response if the model is invalid
            return Json(new { success = false, message = "Invalid form data." });
        }

        [HttpGet]
        public async Task<ViewResult> EditLanguage(int id)
        {
            var language = await _bookRepository .GetLanguageById(id);
            return View(language);
        }
        [HttpPost]
        public async Task<IActionResult> EditLanguage(LanguageModel model)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.UpdateLanguage(model);
                TempData["success"] = "Language updated successfully!";                
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var isDeleted = await _bookRepository.DeleteLanguage(id);

            if (isDeleted)
            {
                TempData["success"] = "Language deleted successfully!";
            }
            else
            {
                TempData["error"] = "Language not found!";
            }

            return RedirectToAction("GetAllLanguage");
        }
        private async Task<string> UploadImage(string folderPath , IFormFile file)
        {
            
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;


            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
        [HttpGet]
        public IActionResult GetLanguageCount()
        {
            int count = _bookRepository.GetLanguageCount();
            return PartialView("~/Views/Shared/_NotificationBell.cshtml", count);
        }
    }
}