using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Data;
using Client.Models;
using Client.Models.PostViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Client.Controllers
{
    [Authorize]
    //[Route("[controller")]
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
        public IActionResult Get(string titleUrl)
        {
            var post = _applicationDbContext.Posts.FirstOrDefault(x => x.TitleUrl.ToLower() == titleUrl.ToLower());
            if (post == null)
            {
                return View("NotFound");
            }

            var model = new CreatePostViewModel
            {
                Title = post.Title,
                TitleUrl = post.TitleUrl,
                Description = post.Description,
                Category = post.Category,
                PostedOn = post.PostedOn,
                Author = post.Author
            };

            return View("ShowPost", model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var user = await _userManager.GetUserAsync(User);
            //для получения только для залогиненого юзера

            var list = _applicationDbContext.Posts
                .OrderByDescending(x => x.PostedOn) // сортировка по дате создания
                //.Where(x => x.Author == user.UserName)
                //для получения только для залогиненого юзера
                .Select(x => new CreatePostViewModel
                {
                    Title = x.Title,
                    PostedOn = x.PostedOn,
                    Author = x.Author,
                    TitleUrl = x.TitleUrl
                })
                .ToList();

            return View("Posts", list);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

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
                TitleUrl = model.TitleUrl,
                Description = model.Description,
                PostedOn = DateTime.UtcNow,
                Author = user.Email
            });

            await _applicationDbContext.SaveChangesAsync();

            return View();
        }

        [HttpPost]
        public IActionResult Edit(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            return View();
        }
    }
}