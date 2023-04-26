using LabW04JesseArnold.Models.Entities;
using Microsoft.AspNetCore.Cors;
using System.ComponentModel;

namespace LabW04JesseArnold.Models.ViewModels
{
    public class DeleteAuthorVM
    {
        public Book? Book { get; set; }
        public int Id { get; set; }
        [DisplayName("FirstName")]
        public string? FirstName { get; set; }
        [DisplayName("LastName")]
        public string? LastName { get; set; }

    }
}
