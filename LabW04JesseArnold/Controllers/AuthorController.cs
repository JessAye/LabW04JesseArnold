
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
        private readonly IBookRepository _authorRepo;

        public AuthorController(IBookRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<IActionResult> Create(int id)
        {
            var book = await _authorRepo.ReadAsync(id);

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
                await _authorRepo.CreateAuthorAsync(bookId, author);
                return RedirectToAction("Details", "Book", new { id = bookId });
            }

            var book = await _authorRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }

            ViewData["Book"] = book;
            return View(authorVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit([Bind("bookId")] int bookId, int authorId)
        {
            var book = await _authorRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }

            var author = await _authorRepo.ReadAsync(authorId);
            if (author == null)
            {
                return RedirectToAction("Details", "Book", new { id = bookId });
            }

            var model = new EditAuthorVM
            {
                Book = book,
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = thi
            };

            return View(model);
        }
    }
   

}




