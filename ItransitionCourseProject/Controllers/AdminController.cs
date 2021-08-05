using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext _database;

        public AdminController(ApplicationContext context)
        {
            _database = context;
        }

        public async Task<IActionResult> AdminPanel()
        {
            ViewBag.AllProfiles = await _database.Users.ToListAsync();
            return View();
        }
    }
}