using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Data;
using Client.Models;
using Client.Models.PostViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(
            ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Posts()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Title_(CreatePostViewModel createPostViewModel)
        //{
        //    _applicationDbContext.Posts

        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user.");
            }

            await _applicationDbContext.Posts.AddAsync(new Post
            {
                Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                Description = model.Description,
                PostedOn = DateTime.UtcNow
            });

            await _applicationDbContext.SaveChangesAsync();

            return View();
        }

    }
}