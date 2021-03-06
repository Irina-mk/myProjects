using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Class5.ViewPart2.Helpers;
using Class5.ViewPart2.Models.Domain;
using Class5.ViewPart2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Class5.ViewPart2.Controllers
{
    public class BookController : Controller
    {
        [Route("all-books")]
        public IActionResult Index()
        {
            List<Book> books = StaticDB.Books;
            return View(books);
        }
        
      public IActionResult Create()
        {
            BookCreateViewModel model = new BookCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(BookCreateViewModel model)
        {
            Book book = new Book();
            int id = StaticDB.Books.Count() + 1;
            Author author = new Author();
            if(model != null)
            {
                book.ISBN = model.ISBN;
                book.Title = model.Title;
                book.Genre = model.Genre;
                author.FullName = model.AuthorFullName;
                author.Age = model.AuthorAge.HasValue ? model.AuthorAge.Value : 0;
                book.Author = author;
                book.IsAvailable = model.isAvailable;
                StaticDB.Books.Add(book);
                    
            }
             return RedirectToAction("Index");
        }



        public IActionResult Edit(Book book)
        {
            Book bookToBeEdited = StaticDB.Books.SingleOrDefault(x => x.Id == book.Id);
            
            Author author = new Author();

            BookEditViewModel editedBook = new BookEditViewModel()
            {
                ISBN = bookToBeEdited.ISBN,
                Title = bookToBeEdited.Title,
                Genre = bookToBeEdited.Genre,
                AuthorFullName = bookToBeEdited.Author.FullName,
                AuthorAge = bookToBeEdited.Author.Age,
                isAvailable = bookToBeEdited.IsAvailable
                

            };

            return View(editedBook);
        }

        [HttpPost]
        public IActionResult Edit(int id, BookEditViewModel model)
        {
            Book bookToBeEdited = StaticDB.Books.FirstOrDefault(x => x.Id == id);
            

            Author author = new Author();

            id = model.Id;
            bookToBeEdited.ISBN = model.ISBN;
            bookToBeEdited.Title = model.Title;
            bookToBeEdited.Genre = model.Genre;
            author.FullName = model.AuthorFullName;
            author.Age = model.AuthorAge.HasValue ? model.AuthorAge.Value : 0;
            bookToBeEdited.Author = author;
            bookToBeEdited.IsAvailable = model.isAvailable;



            return RedirectToAction("Index");

        }



        public IActionResult Details(int id)
        {
            Book book = StaticDB.Books.SingleOrDefault(x => x.Id == id);
            BookDetailsViewModel bookDetails = new BookDetailsViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorsFullName = book.Author.FullName,
                Genre = book.Genre
            };
            return View(bookDetails);
        }

        public IActionResult Delete(int id)
        {
            var res = StaticDB.Books.Where(x => x.Id == id).First();
            StaticDB.Books.Remove(res);
            List<Book> books = StaticDB.Books;

            return View("Index", books);
        }




    }
}
