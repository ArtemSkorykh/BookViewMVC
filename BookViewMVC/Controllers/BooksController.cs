using Microsoft.AspNetCore.Mvc;
using BookViewMVC.Models;

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
            var books = GetBooks();
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        private List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "1984",
                    Author = "George Orwell",
                    Genre  = "Dystopian Novel",
                    Year = 1948
                },
                new Book
                {
                    Id = 2,
                    Title = "The Adventure of the Blue Carbuncle",
                    Author = "Arthur Conan Doyle",
                    Genre = "Detective fiction",
                    Year = 1892
                },

            };
        }
    }
}
