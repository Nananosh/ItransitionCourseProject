using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using ItransitionCourseProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionCourseProject.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationContext _database;

        public CollectionController(ApplicationContext context)
        {
            _database = context;
        }

        [AcceptVerbs("Get", "Post")]
        public bool CheckTitle(string collectionTitle)
        {
            if (_database.Collections.Any(collection => collection.Title == collectionTitle)) return false;
            return true;
        }

        public List<string> GetAllTags()
        {
            var list = new List<string>();
            list.Add("tag");
            list.Add("ggg");
            list.Add("ggwddwg");
            list.Add("ggwddwвцййвцg");
            list.Add("ggwddwвцйййййвцg");
            list.Add("qdwdqwdqwwq");
            return list;
        }

        public IActionResult CreateCollection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(CollectionViewModel collection, string userId)
        {
            return View();
        }
    }
}