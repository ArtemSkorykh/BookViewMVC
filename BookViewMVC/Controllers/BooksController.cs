using Microsoft.AspNetCore.Mvc;
using BookViewMVC.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookViewMVC.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            var books = GetBooks();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        private static List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "1984",
                Author = "George Orwell",
                Genre = "Dystopian Novel",
                Publisher = "UK Books",
                Year = 1948,
                CoverImage = "/images/book1.jpg"
            },
            new Book
            {
                Id = 2,
                Title = "The Adventure of the Blue Carbuncle",
                Author = "Arthur Conan Doyle",
                Genre = "Detective fiction",
                Publisher = "USA Books",
                Year = 1892,
                CoverImage = "/images/book2.jpg"
            },
        };
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            var books = GetBooks();

            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);

            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Genre = book.Genre;
                existingBook.Publisher = book.Publisher;
                existingBook.Year = book.Year;
                existingBook.CoverImage = book.CoverImage;
            }

            return RedirectToAction("Index");
        }
    }
}
