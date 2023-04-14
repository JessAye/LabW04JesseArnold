using System.ComponentModel.DataAnnotations;

namespace LabW04JesseArnold.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(256)]

        public string Title { get; set; } = string.Empty;
        [StringLength(256)]

        public int PublicationYear { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
