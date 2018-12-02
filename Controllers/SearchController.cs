using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Korzh.EasyQuery.Linq;
using konoha.Models;
using konoha.Data;

namespace konoha.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        // POST: Search/Create

        [HttpPost]
        public IActionResult Index(Search pos)
        {
            if (!string.IsNullOrEmpty(pos.text))
            {
                pos.Posts = _dbContext.Post.FullTextSearchQuery(pos.text);
            }

            else
            {
                pos.Posts = _dbContext.Post;
            }

            return View(pos);
        }
    }
}