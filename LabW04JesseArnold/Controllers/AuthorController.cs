using LabW04JesseArnold.Models.Entities;
using LabW04JesseArnold.Models.ViewModels;
using LabW04JesseArnold.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Edit([Bind("bookId")] int id, [Bind("authorId")]int authorId, EditAuthorVM editAuthorVM)
        {
            var book = await _authorRepo.ReadAsync(id);

            if (book == null)
            {
                //  return RedirectToAction(nameof(BookController.Index));
            }

            var author = editAuthorVM.GetAuthorInstance();
            var test = author.FirstName;
            if (author == null)
            {
                //  return RedirectToAction(nameof(BookController.Details), new { id = bookId });
            }

            var model = new EditAuthorVM
            {
                Book = book,
                Id = authorId,
                FirstName = author.FirstName,
                LastName = author.LastName, 
            };

            return View(model);
        }
    }


}




