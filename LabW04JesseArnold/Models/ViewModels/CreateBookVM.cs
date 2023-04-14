using LabW04JesseArnold.Models.Entities;
using System.ComponentModel;

namespace LabW04JesseArnold.Models.ViewModels
{
    public class CreateBookVM
    {
        public string? Title { get; set;}

        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }

        public Book GetBookInstance()
        {
            return new Book
            {
                Id = 0,
                Title = Title ?? String.Empty,
                PublicationYear = PublicationYear
            };
        }
    }
}
