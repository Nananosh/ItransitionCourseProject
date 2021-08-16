﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using ItransitionCourseProject.ViewModels.Search;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Controllers.Search
{
    public class SearchController : Controller
    {
        private readonly ApplicationContext _database;

        public SearchController(ApplicationContext context)
        {
            _database = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchResult(SearchViewModel model)
        {
            ViewBag.Collections = await _database.Collections
                .Include(t => t.Tags)
                .Include(t => t.CollectionTheme)
                .FullTextSearchQuery(model.Query)
                .ToListAsync();

            return View(model);
        }
    }
}