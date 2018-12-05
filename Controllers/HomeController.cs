using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using konoha.Models;
using konoha.Data;

namespace konoha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var applicationDbContext = _context.Post.Include(p => p.Category).Include(p => p.Images).OrderByDescending(p => p.CreatedDate);
            if (!String.IsNullOrEmpty(searchString))
            {
                applicationDbContext = _context.Post.Where(p => p.Title.Contains(searchString)).Include(p => p.Category).Include(p => p.Images).OrderByDescending(p => p.CreatedDate);
            }
            
            ViewData["Categories"] = _context.Category;
            ViewData["Count"] = _context.Post.Count();
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
