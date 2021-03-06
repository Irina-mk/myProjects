using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class5.ViewPart2.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }
    }

    public enum Genre
    {
        Adventure,
        Romance,
        Tech
    }




}
