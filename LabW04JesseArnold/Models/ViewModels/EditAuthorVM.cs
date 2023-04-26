using LabW04JesseArnold.Models.Entities;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations;

namespace LabW04JesseArnold.Models.ViewModels
{
    public class EditAuthorVM
    {
        public Book? Book { get; set; }
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public Author GetAuthorInstance()
        {
            return new Author
            {
                Id = this.Id,
                FirstName = this.FirstName ?? string.Empty,
                LastName = this.LastName ?? string.Empty,
                Book = Book,
            };
        }
    }
}
