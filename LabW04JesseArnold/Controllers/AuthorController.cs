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
        //Create and bind via id and take bookId
        public async Task<IActionResult> Create([Bind(Prefix = "id")] int bookId)
        {
            var book = await _authorRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }
            ViewData["Book"] = book;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int bookId, CreateAuthorVM authorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(authorVM);
            }
            var book = await _authorRepo.ReadAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            var author = new Author()
            {
                FirstName = authorVM.FirstName,
                LastName = authorVM.LastName
            };

            await _authorRepo.CreateAuthorAsync(bookId, author);

            return RedirectToAction("Details", "Book", new { id = bookId });
        }
        //Edit an author (GET)
        public async Task<IActionResult> Edit([Bind(Prefix = "id")] int bookId, int authorId)
        {
            var book = await _authorRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }

            var author = book.Authors.FirstOrDefault(a => a.Id == authorId);

            if (author == null)
            {
                return RedirectToAction("Details", "Book");
            }

            var model = new EditAuthorVM
            {
                Id = authorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Book = book,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int bookId, [Bind("Id, FirstName, LastName, Book")] EditAuthorVM authorVM)
        {

            if (ModelState.IsValid)
            {
                var book = await _authorRepo.ReadAsync(bookId);
                try
                {
                    var authorToUpdate = new Author
                    {
                        Id = authorVM.Id,
                        FirstName = authorVM.FirstName,
                        LastName = authorVM.LastName,
                        Book = book
                    };
                    //Updates the author properties from the bookId and the author instance from the VM
                    await _authorRepo.UpdateAuthorAsync(bookId, authorToUpdate);
                    return RedirectToAction("Details", "Book", new { Id = bookId });
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            var setBook = await _authorRepo.ReadAsync(bookId);
            authorVM.Book = setBook;

            return View(authorVM);
        }
        public async Task<IActionResult> Delete([Bind(Prefix = "id")] int bookId, int authorId)
        {

            if (bookId == null || authorId == null)
            {
                return RedirectToAction("Index", "Book");
            }
            var book = await _authorRepo.ReadAsync(bookId);
            if (book == null)
            {

                return RedirectToAction("Index", "Book");
            }
            //var author = book.Authors.FirstOrDefault(a => a.Id == authorId);
            var author = book.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author == null)
            {
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            var model = new DeleteAuthorVM
            {
                Book = book,
                Id = authorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int bookId, int authorId)
        {
            await _authorRepo.DeleteAuthorAsync(bookId, authorId);

            return RedirectToAction("Details", "Book", new { id = bookId });
        }
    }
}




