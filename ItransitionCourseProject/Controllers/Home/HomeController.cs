using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ItransitionCourseProject.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _database;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationContext context, ILogger<HomeController> logger)
        {
            _database = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Collections = await _database.Collections
                .Include(c => c.CollectionTheme)
                .Include(l => l.Likes)
                .OrderByDescending(c => c.Likes.Count)
                .Take(6)
                .ToListAsync();
            ViewBag.LastAddedCollectionElement = await _database.CollectionElements
                .OrderByDescending(c => c.Id)
                .Take(6)
                .ToListAsync();
            ViewBag.NumberLike = await _database.Likes.CountAsync();
            ViewBag.NumberCollections = await _database.Collections.CountAsync();
            ViewBag.NubmerUsers = await _database.Users.CountAsync();
            ViewBag.NumberComments = await _database.Comments.CountAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}