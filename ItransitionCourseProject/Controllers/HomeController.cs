using System.Diagnostics;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ItransitionCourseProject.Controllers
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
            ViewBag.AllProfiles = await _database.Users.ToListAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}