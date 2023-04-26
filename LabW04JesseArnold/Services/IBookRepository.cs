using LabW04JesseArnold.Models.Entities;

namespace LabW04JesseArnold.Services
{
 

        public interface IBookRepository
        {
            Task<ICollection<Book>> ReadAllAsync();

            Task<Book> CreateAsync(Book book);
            Task<Book> ReadAsync(int id);
        Task<Author> CreateAuthorAsync(int id, Author author);
        Task<Book> UpdateAuthorAsync(int id, Author updatedAuthor);
    }
    }

