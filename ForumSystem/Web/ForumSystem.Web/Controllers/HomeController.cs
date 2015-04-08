using System.Web.Mvc;
using ForumSystem.Common.Repository;
using ForumSystem.Data;
using ForumSystem.Models;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> _posts;

        

        public HomeController(IRepository<Post> posts)
        {
            _posts = posts;
        }

        public ActionResult Index()
        {
            var posts = _posts.All();
            return View(posts);
        }

       
    }
}