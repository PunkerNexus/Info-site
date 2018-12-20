using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Client.Data;
using Client.Models;
using Microsoft.AspNetCore.Identity;
using Client.Models.PostViewModels;

namespace Client.Controllers
{
    public class VideoController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public VideoController(
            ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SendVideo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetVid()
        {
            var vids = _applicationDbContext.Videos
                .OrderByDescending(x => x.PostedOn)
                .Select(x => new VideoViewModel
                {
                    Url = x.Url,
                    Name = x.Name,
                    PostedOn = x.PostedOn
                })
                .ToList();

            return View("ShowVideo", vids);
        }

        [HttpPost]
        public async Task<IActionResult> SendVideo(VideoViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            await _applicationDbContext.Videos.AddAsync(new Video
            {
                Id = Guid.NewGuid().ToString(),
                Url = model.Url,
                Name = model.Name,
                PostedOn = DateTime.UtcNow
            });

            await _applicationDbContext.SaveChangesAsync();

            return View();
        }
    }
}