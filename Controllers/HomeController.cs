using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.FrontEnd.Infrastructure;
using SimpleBlog.FrontEnd.Models;

namespace SimpleBlog.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IPostsRepository postsRepo;

        public HomeController(IPostsRepository postsRepo) 
        {
            this.postsRepo = postsRepo;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["RouteData"] = this.RouteData;

            var viewModel = await postsRepo.GetN<Post>(6);
            ViewData["Model.Featured"] = viewModel.Take(3).ToList();
            ViewData["Model.Boxes"] = viewModel.Skip(3).Take(3).ToList();

            return View();       
        }
    }
}
