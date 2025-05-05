using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookStoreApplication.Controllers;
using BookStoreApplication.Models;
using BookStoreApplication.Repository;
using BookStoreApplication.Services;

public class DropdownController : BaseController
{

    public DropdownController(IBookRepository bookRepository, ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment, IUserService userService,
            IAccountRepository accountRepository)
            : base(bookRepository, languageRepository, webHostEnvironment, 
                userService, accountRepository)
    {

    }
    [Route("[controller]/[action]")]
    [HttpGet]
    public IActionResult MultiDropdown()
    {
        var model = new MultiDropdownModel
        {
            AllOptions = AllLanguages
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult MultiDropdown(MultiDropdownModel model)
    {
        ViewBag.Selected = new List<string>
        {
            model.SelectedOption1,
            model.SelectedOption2,
            model.SelectedOption3,
            model.SelectedOption4,
            model.SelectedOption5,
            model.SelectedOption6
        }.Where(x => !string.IsNullOrEmpty(x)).ToList();

        model.AllOptions = AllLanguages;
        return View(model);
    }
}
