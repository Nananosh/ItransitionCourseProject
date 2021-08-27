using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using ItransitionCourseProject.ViewModels.Collection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Controllers.Collection
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

        [Authorize]
        public async Task<IActionResult> CreateCollection()
        {
            ViewBag.Themes = await _database.CollectionThemes.ToListAsync();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCollection(CreateCollectionViewModel model)
        {
            var user = await _database.Users.FirstOrDefaultAsync(u => u.Id == model.UserId);
            var theme = await _database.CollectionThemes.FirstOrDefaultAsync(t => t.Id == model.Theme.Id);
            if (ModelState.IsValid)
            {
                Models.Collection collection = new Models.Collection
                {
                    User = user,
                    Title = model.Title,
                    Image = model.Image,
                    Description = model.Description,
                    Tags = await InsertTag(model.Tags),
                    CustomFieldsTemplates = model.CustomFields,
                    CollectionTheme = theme
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
            var collection = await _database.Collections
                .Include(u => u.User)
                .Include(t => t.Tags)
                .AsSingleQuery()
                .Include(u => u.User)
                .Include(c => c.Comments)
                .AsSingleQuery()
                .Include(l => l.Likes)
                .ThenInclude(u => u.User)
                .Include(t => t.CollectionTheme)
                .Where(c => c.Id == id)
                .SingleAsync();
            ViewBag.Collection = collection;
            ViewBag.CollectionElement = await _database.CollectionElements
                .Where(i => i.Collection.Id == id).ToListAsync();
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateCollectionElement(int id)
        {
            ViewBag.Collection = await _database.Collections.Include(t => t.CustomFieldsTemplates)
                .Where(c => c.Id == id).SingleAsync();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCollectionElement(CreateCollectionElementViewModel model)
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
                .Include(c => c.Collection)
                .ThenInclude(u => u.User)
                .Include(c => c.CustomFields)
                .ThenInclude(c => c.CustomFieldsTemplates)
                .AsSingleQuery()
                .Include(t => t.Tags)
                .SingleAsync();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment(CollectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var collection =
                    await _database.Collections.FirstOrDefaultAsync(c => c.Id == model.CommentViewModel.CollectionId);
                var user = await _database.Users.FirstOrDefaultAsync(u => u.Id == model.CommentViewModel.UserId);
                var comment = new Comment
                {
                    Text = model.CommentViewModel.Text,
                    User = user,
                    Collection = collection
                };
                await _database.AddAsync(comment);
                await _database.SaveChangesAsync();
            }

            return RedirectToAction("Collection", "Collection", new { id = model.CommentViewModel.CollectionId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CollectionLike(CollectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var collection =
                    await _database.Collections.FirstOrDefaultAsync(c => c.Id == model.LikeViewModel.CollectionId);
                var user = await _database.Users.FirstOrDefaultAsync(u => u.Id == model.LikeViewModel.UserId);
                var like = new Like
                {
                    User = user,
                    Collection = collection
                };
                await _database.AddAsync(like);
                await _database.SaveChangesAsync();
            }

            return RedirectToAction("Collection", "Collection", new { id = model.LikeViewModel.CollectionId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CollectionUnLike(CollectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var like = await _database.Likes
                    .FirstOrDefaultAsync(l =>
                        l.Collection.Id == model.LikeViewModel.CollectionId && l.User.Id == model.LikeViewModel.UserId);
                _database.Remove(like);
                await _database.SaveChangesAsync();
            }

            return RedirectToAction("Collection", "Collection", new { id = model.LikeViewModel.CollectionId });
        }

        private async Task<List<Models.Collection>> GetCollectionByPredicate(
            Expression<Func<Models.Collection, bool>> predicate)
        {
            var collections = await _database.Collections
                .Include(u => u.User)
                .Include(t => t.CollectionTheme)
                .Where(predicate)
                .ToListAsync();
            return collections;
        }

        [HttpGet]
        public async Task<IActionResult> AllCollection(CollectionTheme collectionTheme)
        {
            if (collectionTheme.Theme == null)
            {
                ViewBag.Collections = await GetCollectionByPredicate(c => true);
            }
            else
            {
                ViewBag.Collections =
                    await GetCollectionByPredicate(c => c.CollectionTheme.Theme == collectionTheme.Theme);
            }

            ViewBag.CollectionThemes = await _database.CollectionThemes.ToListAsync();
            return View();
        }

        public async Task<IActionResult> DeleteCollection(int id)
        {
            _database.Remove(await _database.Collections.FirstOrDefaultAsync(c => c.Id == id));
            await _database.SaveChangesAsync();
            return RedirectToAction("AllCollection", "Collection");
        }

        public async Task<IActionResult> DeleteCollectionElement(int id, int idCollection)
        {
            _database.Remove(await _database.CollectionElements
                .Include(c => c.CustomFields)
                .FirstOrDefaultAsync(c => c.Id == id));
            await _database.SaveChangesAsync();
            return RedirectToAction("Collection", "Collection", new { id = idCollection });
        }

        [HttpGet]
        public async Task<IActionResult> EditCollection(int id)
        {
            ViewBag.Collection = await _database.Collections
                .FirstOrDefaultAsync(i => i.Id == id);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCollection(EditCollectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var collection = await _database.Collections.FirstOrDefaultAsync(i => i.Id == model.Id);
                collection.Title = model.Title;
                collection.Description = model.Description;
                collection.Image = model.Image;
                await _database.SaveChangesAsync();
                return RedirectToAction("Collection", "Collection", new { id = model.Id });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditCollectionElement(int id)
        {
            ViewBag.CollectionElement = await _database.CollectionElements
                .FirstOrDefaultAsync(i => i.Id == id);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCollectionElement(EditCollectionElementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var collectionElement = await _database.CollectionElements.FirstOrDefaultAsync(i => i.Id == model.Id);
                collectionElement.Title = model.Title;
                collectionElement.Description = model.Description;
                collectionElement.Image = model.Image;
                await _database.SaveChangesAsync();
                return RedirectToAction("Collection", "Collection", new { id = model.Id });
            }

            return View(model);
        }
    }
}