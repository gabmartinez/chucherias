using System;
// using System.IO;
using System.Collections.Generic;
using System.Linq;
// using System.Net.Http.Headers;
// using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using konoha.Models;
using konoha.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace konoha.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        // private readonly IHostingEnvironment _environment;

        public PostsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            // _environment = env;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Post.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Category.ToList();
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostID,Title,CategoryID,Description,IsAcctive")] Post post)
        {
            if (ModelState.IsValid)
            {
                // Console.WriteLine("Come on!");
                // var files = HttpContext.Request.Form.Files;
                // Console.WriteLine("Come on! Yes");
                // foreach (var Image in files)
                // {
                //     Console.WriteLine("Here we are!");
                //     if (Image != null && Image.Length > 0)
                //     {
                //         var file = Image;
                //         Console.WriteLine("Here we are 1");
                //         var uploads = Path.Combine(_environment.WebRootPath, "uploads\\img\\posts");
                //         Console.WriteLine("Here we are 2");
                //         if (file.Length > 0)
                //         {
                //             Console.WriteLine("Here we are 3");
                //             var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                //             System.Console.WriteLine(fileName);
                //             using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                //             {
                //                 await file.CopyToAsync(fileStream);
                //                 Console.WriteLine(file.FileName);
                //                 // post.Images.Add(new PostImage { ImagePath = file.FileName });
                //             }
                //         }
                //     }
                // }
                
                post.CreatedDate = DateTime.Now;
                post.UserID = _userManager.GetUserId(User);
                // Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", post.PostID, post.Title, post.UserID, post.CategoryID, post.Description, post.CreatedDate, post.IsAcctive);
                _context.Add(post);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Category.ToList();
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostID,Title,CategoryID,Description,UserID,CreatedDate,IsAcctive")] Post post)
        {
            if (id != post.PostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.PostID == id);
        }
    }
}
