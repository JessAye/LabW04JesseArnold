using LabW04JesseArnold.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace LabW04JesseArnold.Models.ViewModels
{
    public class CreateAuthorVM
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public Author GetAuthorInstance()
        {
            return new Author
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }

}