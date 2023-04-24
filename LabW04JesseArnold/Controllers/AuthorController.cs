
using LabW04JesseArnold.Controllers;
using LabW04JesseArnold.Models.Entities;
using LabW04JesseArnold.Models.ViewModels;
using LabW04JesseArnold.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace LabW04JesseArnold.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookRepository _authorrepository;

        public AuthorController(IBookRepository authorrepository)
        {
            _authorrepository = authorrepository;
        }

        public async Task<IActionResult> Create(int id)
        {
            var book = await _authorrepository.ReadAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(BookController.Index));
            }

            ViewData["Book"] = book;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int bookId, CreateAuthorVM authorVM)
        {
            if (ModelState.IsValid)
            {
                var author = authorVM.GetAuthorInstance();
                await _authorrepository.CreateAuthorAsync(bookId, author);
                return RedirectToAction("Details", "Book", new { id = bookId });
            }

            var book = await _authorrepository.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }

            ViewData["Book"] = book;
            return View(authorVM);
        }

    }
    [HttpGet]
    public async Task<IActionResult> Edit(int bookId, int authorId)
    {
        int id = bookId;
        var book = await _authorreporsitory.Re
        return View();
    }

}


}

