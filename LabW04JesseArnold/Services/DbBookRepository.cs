using LabW04JesseArnold.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabW04JesseArnold.Services
{
    public class DbBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public DbBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return book;
        }
        public async Task<Book> ReadAsync(int id)
        {
            var book = await _db.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task<ICollection<Book>> ReadAllAsync()
        {
            return await _db.Books.Include(p => p.Authors).ToListAsync();
        }

        public async Task<Author> CreateAuthorAsync(int bookId, Author author)
        {
            var book = await _db.Books.FindAsync(bookId);
            book.Authors.Add(author);
            author.Book = book;
            _db.SaveChanges();
            return author;
        }

        public async Task<Author> UpdateAuthorAsync(int bookId, Author authorToUpdate)
        {
            var book = await _db.Books
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                throw new ArgumentException($" {bookId} not found");
            }
            var currentAuthor = book.Authors.FirstOrDefault(a => a.Id == authorToUpdate.Id);
            if (currentAuthor == null)
            {
                throw new ArgumentException($"bookId {bookId} has no author ");
            }

            currentAuthor.FirstName = authorToUpdate.FirstName;
            currentAuthor.LastName = authorToUpdate.LastName;

            await _db.SaveChangesAsync();
            return currentAuthor;
        }
        public async Task<Author> DeleteAuthorAsync( int bookId, int authorId)
        {

            var book = await _db.Books
                .Include(b => b.Authors)
                .SingleOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException($"book with id{bookId}");

            }
            var authorToDelete = book.Authors.SingleOrDefault(a => a.Id == authorId);

            if (authorToDelete == null)
            {
                throw new ArgumentException($"there is no author with id of {authorId} in the book with bookId of: {bookId}");
            }
            book.Authors.Remove(authorToDelete);
            await _db.SaveChangesAsync();
            return authorToDelete;
        }
    }
}
