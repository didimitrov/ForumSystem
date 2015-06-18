using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Common.Repository;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.PostModels;
using ForumSystem.Web.ViewModels.SideBar;
using PagedList;

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

        //public ActionResult Search(string search, string searchBy, string sortBy, int? page)
        //{
        //    ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";

        //    var searchResults = new List<Post>();

        //    if (!string.IsNullOrWhiteSpace(search))
        //    {
        //        foreach (var thread in _posts.All())
        //        {
        //            searchResults.Add(thread);
        //        }

        //        if (!string.IsNullOrWhiteSpace(search))
        //            searchResults = searchResults.Where(m => m.Title.ToLower().Contains(search)).ToList();

        //        switch (sortBy)
        //        {
        //            case "Name desc":
        //                searchResults = searchResults.OrderByDescending(a => a.Id).ToList();
        //                break;
        //            default:
        //                searchResults = searchResults.OrderBy(a => a.Id).ToList();
        //                break;
        //        }
        //    }


        //    return View(searchResults.ToPagedList(page ?? 1, 3));
        //}
    }
}