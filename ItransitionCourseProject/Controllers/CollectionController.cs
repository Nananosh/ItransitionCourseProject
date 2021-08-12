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
            if (tags == null)
            {
                return list;
            }

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
        public async Task<IActionResult> CreateCollection(CollectionViewModel model)
        {
            var user = _database.Users.FirstOrDefault(u => u.Id == model.UserId);
            if (ModelState.IsValid)
            {
                Collection collection = new Collection
                {
                    User = user,
                    Title = model.Title,
                    Image = model.Image,
                    Description = model.Description,
                    Tags = await InsertTag(model.Tags),
                    CustomFieldsTemplates = model.CustomFields
                };
                await _database.AddAsync(collection);
                await _database.SaveChangesAsync();
                return RedirectToAction("Collection", "Collection", new { collection.Id });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Collection(int id)
        {
            ViewBag.Collection = await _database.Collections
                .Include(t => t.Tags)
                .AsSingleQuery()
                .Include(u => u.User)
                .Include(c => c.Comments)
                .Where(c => c.Id == id)
                .SingleAsync();;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCollectionElement(int id)
        {
            ViewBag.Collection = await _database.Collections.Include(t => t.CustomFieldsTemplates)
                .Where(c => c.Id == id).SingleAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollectionElement(CollectionElementViewModel model)
        {
            var collection = _database.Collections.FirstOrDefault(c => c.Id == model.CollectionId);
            foreach (var customField in model.CustomFields)
            {
                customField.CustomFieldsTemplates =
                    _database.CustomFieldsTemplates.FirstOrDefault(c => c.Id == customField.CustomFieldsTemplates.Id);
            }

            if (ModelState.IsValid)
            {
                var collectionElement = new CollectionElement()
                {
                    Collection = collection,
                    Title = model.Title,
                    Image = model.Image,
                    Description = model.Description,
                    Tags = await InsertTag(model.Tags),
                    CustomFields = model.CustomFields
                };
                await _database.AddAsync(collectionElement);
                await _database.SaveChangesAsync();
                return RedirectToAction("CollectionElement", "Collection", new { collectionElement.Id });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CollectionElement(int id)
        {
            ViewBag.CollectionElement = await _database.CollectionElements
                .Where(c => c.Id == id)
                .Include(c => c.CustomFields)
                .ThenInclude(c => c.CustomFieldsTemplates)
                .AsSingleQuery()
                .Include(t => t.Tags)
                .SingleAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var collection  = await _database.Collections.FirstOrDefaultAsync(c => c.Id == model.CollectionId);
                var user = await _database.Users.FirstOrDefaultAsync(u => u.Id == model.UserId);
                var comment = new Comment
                {
                    Text = model.Text,
                    User = user,
                    Collection = collection
                };
                await _database.AddAsync(comment);
                await _database.SaveChangesAsync();
            }
            return RedirectToAction("Collection", "Collection", new { id = model.CollectionId });
        } 
    }
}