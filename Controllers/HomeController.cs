using ConwayHogan_Mission11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;
using System.Diagnostics;

namespace ConwayHogan_Mission11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepo;

        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1); // If no page is specified, default to the first page.
            var books = _bookRepo.Books.OrderBy(i => i.Title).ToPagedList(pageNumber, pageSize);

            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
