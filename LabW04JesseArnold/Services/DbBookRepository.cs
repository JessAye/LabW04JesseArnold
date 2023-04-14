using LabW04JesseArnold.Models.Entities;
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
        public async Task<Book?> ReadAsync(int id)
        {

            return await _db.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);


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
    
    }
}
