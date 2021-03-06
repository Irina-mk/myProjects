using Class5.ViewPart2.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Class5.ViewPart2.Models.ViewModels
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Book title")]
        public string Title { get; set; }
        [Display(Name = "Book author")]
        public string AuthorsFullName { get; set; }
        [Display(Name = "Book genre")]
        public Genre Genre { get; set; }
    }
}
