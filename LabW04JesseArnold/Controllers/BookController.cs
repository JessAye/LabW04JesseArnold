
using LabW04JesseArnold.Services;
using Microsoft.AspNetCore.Mvc;
using LabW04JesseArnold.Models.ViewModels;

namespace LabW04JesseArnold.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task <IActionResult> Index()
        {
            var allBooks = await _bookRepository.ReadAllAsync();
            var model = allBooks.Select(b =>
               new BookDetailsVM
               {
                   Id = b.Id,
                   Title = b.Title,
                   PublicationYear = b.PublicationYear,
                   NumberOfAuthors = b.Authors.Count
               });
            return View(model);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateBookVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var book = model.GetBookInstance();

            await _bookRepository.CreateAsync(book);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            var book = await _bookRepository.ReadAsync(id);

            if (book == null)
            {
                return RedirectToAction("Index");
            }

            var model = new BookDetailsVM
            {
                Id = book.Id,
                Title = book.Title,
                Authors = book.Authors,
                PublicationYear = book.PublicationYear
            };

            return View("Details", model);
        }

      


    }
}
