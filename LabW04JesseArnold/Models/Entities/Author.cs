using System.ComponentModel.DataAnnotations;

namespace LabW04JesseArnold.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(128)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
