using System.ComponentModel.DataAnnotations;

namespace LabW04JesseArnold.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int PublicationYear { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
