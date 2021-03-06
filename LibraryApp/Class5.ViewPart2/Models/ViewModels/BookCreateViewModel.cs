using Class5.ViewPart2.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Class5.ViewPart2.Models.ViewModels
{
    public class BookCreateViewModel
    {
        
        public string ISBN { get; set; }
        public string Title { get; set; }
        [Display(Name = "Author fullname")]
        public string AuthorFullName { get; set; }
        [Display (Name = "Author age")]
        public int? AuthorAge { get; set; }
        public Genre Genre { get; set; }
        [Display (Name = "Availability")]
        public bool isAvailable { get; set; }
    }
}
