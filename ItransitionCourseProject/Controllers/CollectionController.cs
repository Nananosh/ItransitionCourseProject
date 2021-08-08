using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using ItransitionCourseProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationContext _database;

        public CollectionController(ApplicationContext context)
        {
            _database = context;
        }

        public IQueryable<string> GetAllTags()
        {
            return _database.Tags.Select(name => name.TagName);
        }

        public async Task<List<Tag>> InsertTag(string tags)
        {
            var list = new List<Tag>();
            foreach (var tag in tags.Split(','))
            {
                if (await _database.Tags.AnyAsync(t => t.TagName == tag))
                {
                    var t = await _database.Tags.FirstOrDefaultAsync(t => t.TagName == tag);
                    list.Add(t);
                }
                else
                {
                    var t = new Tag
                    {
                        TagName = tag
                    };
                    await _database.AddAsync(t);
                    await _database.SaveChangesAsync();
                    list.Add(t);
                }
            }

            return list;
        }

        public IActionResult CreateCollection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(CollectionViewModel model, string userId)
        {
            var user = _database.Users.FirstOrDefault(u => u.Id == userId);
            if (ModelState.IsValid)
            {
                Collection collection = new Collection
                {
                    User = user,
                    Title = model.Title,
                    Image = model.Image,
                    Description = model.Description,
                    Tags = await InsertTag(model.Tags)
                };
                await _database.AddAsync(collection);
                await _database.SaveChangesAsync();
                return Redirect($"/Collection/Collection?id={collection.Id}");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Collection(int id)
        {
            ViewBag.Collection = _database.Collections.Include(c => c.Tags).Where(c => c.Id == id);
            return View();
        }
    }
}