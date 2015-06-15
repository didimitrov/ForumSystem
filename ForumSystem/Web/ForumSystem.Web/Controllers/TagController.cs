using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Common.Repository;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.SideBar;

namespace ForumSystem.Web.Controllers
{
    //replaced with category/home controller

    public class TagController : Controller
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagController(IRepository<Tag> tagRepository)
        {
            this._tagRepository = tagRepository;
        }

        // GET: Tag
        public ActionResult Index()
        {
          //  var tags = _tagRepository.All().Project().To<TagViewModel>().ToList();

            var tags = _tagRepository.All().Select(x => new TagViewModel()
            {
                Name = x.Name,
                Posts = x.Posts,
                PostCount = x.Posts.Count
            }).ToList();
            return View(tags);
        }
    }
}