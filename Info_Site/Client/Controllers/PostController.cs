using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }


    }
}