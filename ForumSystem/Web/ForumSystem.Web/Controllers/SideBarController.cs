using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Common.Repository;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.Home;
using ForumSystem.Web.ViewModels.SideBar;

namespace ForumSystem.Web.Controllers
{
    public class SideBarController : Controller
    {
        private readonly IRepository<Post> _posts;
        private readonly IRepository<Tag> _tags;

        public SideBarController(IRepository<Post> posts, IRepository<Tag> tags)
        {
            _posts = posts;
            _tags = tags;
        }

        // GET: SideBar
        public ActionResult Index()
        {
            var model = new SideBarViewModel
            {
                Posts = _posts.All().OrderByDescending(x => x.AskedOn).Project().To<IndexBlogPostViewModel>().Take(5),

                Tags = _tags.All().Project().To<TagViewModel>().OrderByDescending(x => x.PostCount)
            };

            return PartialView("_SideBarPartial", model);
        }
    }
}