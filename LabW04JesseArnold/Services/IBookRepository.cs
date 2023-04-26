using LabW04JesseArnold.Models.Entities;

namespace LabW04JesseArnold.Services
{
 

        public interface IBookRepository
        {
            Task<ICollection<Book>> ReadAllAsync();

            Task<Book> CreateAsync(Book book);
            Task<Book> ReadAsync(int id);
        Task<Author> CreateAuthorAsync(int bookId, Author author);
        Task<Author> UpdateAuthorAsync(int bookId, Author updatedAuthor);
    }
    }

