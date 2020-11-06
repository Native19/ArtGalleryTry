using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Art_gallery.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Art_gallery.Controllers
{
   public class MainController:Controller
   {

        ApplicationContext _context;
        IWebHostEnvironment _appEnvironment;

        public MainController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult LoadPage()
        {
            List<string> tags = _context.Tags.Select(p => p.Name).ToList();
            ViewBag.Tags = tags;
            return View(tags);
        }
        [HttpGet]
        public IActionResult LoadImages(string category)
        {
            var posts = _context.Posts.Where(p => p.PostTags.Select(o => o.Tag).Select(o => o.Name).Contains(category)).Select(el => el.Path);
            return View(posts);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                User user = _context.Users.First(user => user.Login == HttpContext.User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Account", "Login");
                else
                {
                    Guid id = Guid.NewGuid();
                    //List<PostTag> postTagsList = new PostTag()
                    Post file = new Post { Name = uploadedFile.FileName, Path = path, DateTime = DateTime.Now, User = user, UserId = user.Id, Id = id };
                    _context.Posts.Add(file);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("LoadPage");
        }

        //        [HttpPost]
        //        public ActionResult BookSearch(string name)
        //        {
        //            var allPosts = db.Posts.Where(a => a.Author.Contains(name)).ToList();
        //            if (allbooks.Count <= 0)
        //            {
        //                return HttpNotFound();
        //            }
        //            return PartialView(allbooks);
        //        }
    }
}
