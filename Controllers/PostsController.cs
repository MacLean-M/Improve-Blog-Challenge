using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.FrontEnd.Infrastructure;
using SimpleBlog.FrontEnd.Models;
using SimpleBlog.FrontEnd.ViewModels;

namespace SimpleBlog.FrontEnd.Controllers
{
    public class PostsController : Controller
    {
        protected readonly IPostsRepository postsRepo;
        protected readonly ICommentsRepository commentsRepo;

        public PostsController(IPostsRepository postsRepo, ICommentsRepository commentsRepo) 
        {
            this.postsRepo = postsRepo;
            this.commentsRepo = commentsRepo;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["RouteData"] = this.RouteData;

            var posts = await postsRepo.GetAll<Post>();

            foreach(var post in posts)
            { 
                var comments = await commentsRepo.GetAll<Comment>(post.Id);
                post.CommentCount = comments.Count();
            }

            var vm = new PostsViewModel 
            {
                Posts = posts.ToList()
            };
            return View(vm);
        }

        public async Task<IActionResult> Details(int id, string slug = null)
        {
            ViewData["RouteData"] = this.RouteData;

            var post = await postsRepo.Get<Post>(id);
            var comments = await commentsRepo.GetAll<Comment>(id);
            var vm = new PostDetailsViewModel 
            {
                Post = post,
                Comments = comments.ToList(),
            };
            
            return View(vm);
        }
    }
}
