using System.Linq;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using ItransitionCourseProject.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Controllers.Profile
{
    public class ProfileController : Controller
    {
        private readonly ApplicationContext _database;

        public ProfileController(ApplicationContext context)
        {
            _database = context;
        }

        public async Task<string> GetUserImage(string id)
        {
            User user = await _database.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user.UserImage;
        }

        public async Task<IActionResult> Profile(string id)
        {
            ViewBag.User = await _database.Users
                .SingleOrDefaultAsync(u => u.Id == id);
            ViewBag.UserCollections = await _database.Collections
                .Include(l => l.Likes)
                .Where(u => u.User.Id == id)
                .ToListAsync();
            ViewBag.LikeCollections = await _database.Likes
                .Include(c => c.Collection)
                .Where(u => u.User.Id == id)
                .ToListAsync();
            ViewBag.UserComments = await _database.Comments
                .Include(c => c.Collection)
                .Include(c => c.User)
                .Where(с => с.User.Id == id)
                .ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(string id)
        {
            ViewBag.Profile = await _database.Users.FirstOrDefaultAsync(p => p.Id == id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var profile = await _database.Users.FirstOrDefaultAsync(p => p.Id == model.Id);
                profile.UserImage = model.Image;
                await _database.SaveChangesAsync();
                return RedirectToAction("Profile", "Profile", new { id = model.Id });
            }

            return View(model);
        }
    }
}