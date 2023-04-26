using LabW04JesseArnold.Models.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabW04JesseArnold.Models.ViewModels
{
    public class BookDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }

        [DisplayName("Number of Authors")]
        public int NumberOfAuthors { get; set; }

       public ICollection<Author>? Authors { get; set; }
    }
}
